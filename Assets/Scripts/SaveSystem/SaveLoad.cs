using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
	[SerializeField] private Transform player;
	[SerializeField] private Inventory inva;

	void Awake(){
		inva = player.GetComponent<Inventory>();
	}

	public void Save(LegacyDrop drop){
		int slot = drop.getToggleId();
		PlayerStorage sv = new PlayerStorage(player.position, inva.GetCount(), inva.GetType(), inva.GetItemsFromScene(), inva.GetPositionFromScene());
		HackerSave saver = new HackerSave($"./SaveIA_{slot}.json");
		saver.writeFile(sv);
	}

	public void Load(LegacyDrop drop){
		int slot = drop.getToggleId();
		HackerSave loader = new HackerSave($"./SaveIA_{slot}.json");
		PlayerStorage data = loader.readFile();
		player.position = data.position;
		inva.Load(data.inventoryId, data.inventoryCount);
		inva.LoadItemsToScene(data.idPlace, data.posPlace);
	}
}
