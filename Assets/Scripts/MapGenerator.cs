using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {



	[SerializeField]
	public GameObject wall;     //1 by 1 wall
	string mapBinary;

	// Use this for initialization
	void Start () {
		mapBinary = ReadMapBySystem("test");
		GenerateMap(mapBinary);
	}

	string ReadMapBySystem(string stage)
	{
		try
		{
			string data = System.IO.File.ReadAllText("../Resources/Maps/" + stage + ".dat");
			Debug.Log("Successed to extract this stage!");
			return data;
		}
		catch(System.IO.IOException e)
		{
			Debug.Log("Failed to extract this stage.");
			Debug.Log(e.StackTrace);
			return "";
		}
	}

	void GenerateMap(string mapBin)
	{
		int x, y;
		char c;
		x = mapBin
	}

	void GenerateWall(Vector2 pos)
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
