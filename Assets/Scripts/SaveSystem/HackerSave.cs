//HackerSave Lib

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class HackerSave
{
	private string name;

	public HackerSave(string fileName){
		this.name = fileName;
	}

	public bool writeFile(PlayerStorage obj){
		// Create a file to write to.
		using (StreamWriter sw = new StreamWriter(name))
		{
			sw.WriteLine(JsonUtility.ToJson(obj));
			return true;
		}
		//return false;
	}

	public PlayerStorage readFile(){
		using (StreamReader sr = new StreamReader(name))
		{
			string s = sr.ReadLine();
			PlayerStorage data = JsonUtility.FromJson<PlayerStorage>(s);
			return data;
		}
	}
}

[Serializable]
public struct PlayerStorage
{
	public Vector3 position;
	public int[] inventoryCount;
	public int[] inventoryId;
	public int[] idPlace;
	public Vector3[] posPlace;
	public int[] dialogs;

	public PlayerStorage(Vector3 position, int[] inventoryCount, int[] inventoryId, int[] idPlace, Vector3[] posPlace, int[] dialogs) {
		this.position = position;
		this.inventoryId = inventoryId;
		this.inventoryCount = inventoryCount;
		this.idPlace = idPlace;
		this.posPlace = posPlace;
		this.dialogs = dialogs;

	}
}