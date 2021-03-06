﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	[SerializeField]
	public GameObject map;
	[SerializeField]
	public GameObject wall;
	[SerializeField]
	public GameObject wall_movable;
	[SerializeField]
	public GameObject empty;
	[SerializeField]
	public GameObject ballSpawnPoint;
	[SerializeField]
	public GameObject goalSpawnPoint;
	[SerializeField]
	public GameObject ball;
	[SerializeField]
	public GameObject goal;
	[SerializeField]
	public GameObject trap;
	string mapBinary;

	private int goalNum = 0;
	public int GoalNum { get { return goalNum; } }

	// Use this for initialization
	public void Generate(int lv1, int lv2) 
	{
		mapBinary = ReadMapBySystem(lv1.ToString() + "-" + lv2.ToString());
        if (mapBinary == null)
        {
            Debug.Log("There is not TextAsset for this stage. Failed.");
            return;
        }
		GenerateMap(mapBinary);
	}

	string ReadMapBySystem(string stage)
	{
        string data;
        TextAsset Assetdata = null;
        //Deprecated
        /*
		try
		{
			data = System.IO.File.ReadAllText("Assets/Resources/Maps/" + stage + ".txt");
			Debug.Log("Successed to extract this stage!");
			return data;
		}
		catch(System.IO.IOException e)
		{
			Debug.Log("Failed to extract this stage.");
			Debug.Log(e.StackTrace);
			return "";
		}
        */
        try
        {
            Assetdata = Resources.Load("Maps/"+ stage) as TextAsset;
        }
        catch(UnityException e)
        {
            Debug.Log(e.StackTrace);
        }
        return Assetdata.text;
        
	}

	void GenerateMap(string mapBin)
	{
		int x = 0, y = 0;
		string[] lineMapBin = mapBin.Split('\n');
		foreach(string bin in lineMapBin)
		{
			foreach(char b in bin)
			{
				GameObject spn = null;
				switch(b)
				{
					case '`':
						spn = empty;
						break;
					case '1':
						spn = wall;
						break;
                    case '2':
                        spn = wall_movable;
                        break;
                    case 'X':
                        spn = trap;
                        break;
					case '@':
						spn = ballSpawnPoint;
						break;
					case '&':
						spn = goalSpawnPoint;
						break;
					case '\r':
						spn = empty;
						break;
				}
				if (spn == null)
					Debug.Log("There is no spawned object");
				else if(spn != empty)
					Instantiate(spn, new Vector3(x, 0, -y + 11), new Quaternion(), map.GetComponent<Transform>());
				x++;
			}
			x = 0;
			y++;
		}
		Transform[] childList = map.transform.GetComponentsInChildren<Transform>();
		int p = 0, q = 0;
		foreach(Transform child in childList)
		{
			if(child.name.Contains("BallSpawnPoint"))
			{
				Instantiate(ball, child.position, child.rotation).tag = "Ball";
				p++;
			}
			else if(child.name.Contains("GoalSpawnPoint"))
			{
				Instantiate(goal, child.position, child.rotation).tag = "Goal";
				q++;
			}
		}
		if (p != q)
			Debug.Log("The numbers of balls and goals do not match.");
		else
			goalNum = p;
	}
}
