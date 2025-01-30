using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
	[SerializeField] private Transform player;
	public void Save(LegacyDrop drop){
		int slot = drop.getToggleId();
		PlayerStorage sv = new PlayerStorage(player.position);
		HackerSave saver = new HackerSave($"./SaveIA_{slot}.json");
		saver.writeFile(sv);
	}

	public void Load(LegacyDrop drop){
		int slot = drop.getToggleId();
		HackerSave loader = new HackerSave($"./SaveIA_{slot}.json");
		PlayerStorage data = loader.readFile();
		player.position = data.position;
	}
}
