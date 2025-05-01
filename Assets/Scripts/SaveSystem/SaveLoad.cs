using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
	[SerializeField] private Transform player;
	[SerializeField] private Inventory inva;
	[SerializeField] private DiaMan[] dm;

	void Awake(){
		inva = player.GetComponent<Inventory>();
	}

	public void Save(LegacyDrop drop){
		int slot = drop.getToggleId();
		int[] diam = new int[dm.Length];
		for(int i = 0; i < dm.Length; i++){
			diam[i] = dm[i].rep;
		}
		PlayerStorage sv = new PlayerStorage(player.position, inva.GetCount(), inva.GetType(), inva.GetItemsFromScene(), inva.GetPositionFromScene(), diam);
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

		for(int i = 0; i < dm.Length; i++){
			dm[i].rep = data.dialogs[i];
		}
	}
}
