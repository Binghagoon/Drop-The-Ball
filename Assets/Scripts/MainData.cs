using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainData : MonoBehaviour {

	public int gameLv1 = 1;
	public int gameLv2 = 1;
    private static MainData instance;

    protected MainData(){}

    public static MainData Instance() { return instance; }

    private void Awake()
    {
        if (instance == null) instance = this;
        else;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
