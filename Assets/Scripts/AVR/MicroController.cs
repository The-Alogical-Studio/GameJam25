using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroController : MonoBehaviour
{
	[SerializeField] private bool inColl;

	[SerializeField] private Controller player;
	[SerializeField] private Inventory inv;
	[SerializeField] private GameObject[] modules;

	void Update(){
		if(Input.GetKeyDown(KeyCode.X) && inColl){
			player.mode = !player.mode;
		}
		if(Input.GetKeyDown(KeyCode.F) && inColl){
			int id = inv.GetHandleItem();
			if(id != -1){
				modules[id].SetActive(true);
				inv.DestroyHandleItem();
			}
		}
	}

	void OnTriggerEnter(Collider other){
		inColl = true;
	}
	
	void OnTriggerExit(Collider other){
		inColl = true;
	}
}
