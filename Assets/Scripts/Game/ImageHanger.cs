using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageHanger : MonoBehaviour {

    static GameObject canvas;
    static List<ImageHanger> balls;
    static List<ImageHanger> goals;

    GameObject target;
    Image image;
    bool isMovable = false;

    static ImageHanger() {
        balls = new List<ImageHanger>();
        goals = new List<ImageHanger>();
    }

    static Vector3 getRectPos(GameObject obj)
    {
		Vector3 objPos = Camera.main.WorldToViewportPoint(obj.transform.position);
		RectTransform CanvasRect = GameUIManager.canvas.GetComponent<RectTransform>();
		objPos.x = objPos.x * CanvasRect.sizeDelta.x - CanvasRect.sizeDelta.x * 0.5f;
		objPos.y = objPos.y * CanvasRect.sizeDelta.y - CanvasRect.sizeDelta.y * 0.5f;
        return objPos;
    }

    void SetRectPos(Vector3 pos)
    {
        image.rectTransform.anchoredPosition = pos;
    }

	// Update is called once per frame
	void Update () {
        if (isMovable)
            SetRectPos(getRectPos(target));
	}

    public void Initialize(GameObject target, Sprite sprite, Vector3 scale)
    {
        image = GetComponent<Image>();
        this.target = target;
        image.sprite = sprite;
        image.rectTransform.localScale = scale;
        SetRectPos(getRectPos(target));
        if (target.name.Contains("Ball"))
        {
            balls.Add(this);
            isMovable = true;
        }
        if(target.name.Contains("Goal"))
        {
            goals.Add(this);
        }
    }

    // Use this for initialization
    void Start ()
    {
        
    }
	
}
