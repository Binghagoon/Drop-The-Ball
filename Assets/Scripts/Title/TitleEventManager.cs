using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleEventManager : MonoBehaviour {

    [SerializeField]
    GameObject Title;
    [SerializeField]
    GameObject LevelSelect;
    [SerializeField]
    GameObject Setting;

    private static TitleEventManager instance;
    public static TitleEventManager Instance() { return instance; }

	// Use this for initialization
	void Awake () {
        if (instance == null) instance = this;
        else Destroy(this);

        if (MainData.Instance().isPlaying)
        {
            OnClickGameStart(null);
            ChangeLevelImage(MainData.Instance().gameLv1);
        }
	}
    
    public void OnClickGameStart(Button b)
    {
        Title.SetActive(false);
        LevelSelect.SetActive(true);
    }
    
    public void OnClickTitleExit(Button b)
    {
        Application.Quit();
    }

    public void OnClickSetting(Button b)
    {
        Setting.SetActive(!Setting.activeSelf);
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            bool isMuted;
            if(button.name.Contains("BGM"))
            {
                isMuted = MainData.Instance().BGMmute;
            }
            else
                isMuted = MainData.Instance().EffectMute;

            if(isMuted)
                button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/MusicImageMute");
            else
                button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/MusicImagePlay");
                
        }
    }

    public void OnValueChangedSensitivity(Slider slider)
    {
        MainData.Instance().sensitivity = slider.value;
    }

    public void OnClickSoundButton(Button button)
    {
        bool isMuted;
        if (button.name.Contains("BGM"))
        {
            isMuted = !MainData.Instance().BGMmute;
            MainData.Instance().BGMmute = isMuted;
            AudioManager.Instance().GetComponent<AudioSource>().mute = isMuted;
        }
        else
        {
            isMuted = !MainData.Instance().BGMmute;
            MainData.Instance().BGMmute = isMuted;
        }
        if(isMuted)
            button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/MusicImageMute");
        else
            button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/MusicImagePlay");
    }

    public void OnClickPrev(Button b)
    {
        int lv1now = MainData.Instance().gameLv1;
        if (lv1now == 1) return;
        else MainData.Instance().gameLv1 = lv1now - 1;
        ChangeLevelImage(lv1now - 1);
    }

    public void OnClickNext(Button b)
    {
        int lv1now = MainData.Instance().gameLv1;
        if (lv1now == 3) return;
        else MainData.Instance().gameLv1 = lv1now + 1;
        ChangeLevelImage(lv1now + 1);
    }

    public void OnClickNumber(Button b)
    {
        int lv2 = int.Parse(b.transform.name);
        MainData.Instance().gameLv2 = lv2;
        MainData.Instance().isPlaying = true;
		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void OnClickSelectLevelExit(Button b)
    {
        Title.SetActive(true);
        LevelSelect.SetActive(false);
    }

    void ChangeLevelImage(int level)
    {
        Sprite img = Resources.Load<Sprite>("Images/Title/Select_lv" + level) ;
        LevelSelect.transform.GetComponentInChildren<Image>().sprite = img;
    }
}
