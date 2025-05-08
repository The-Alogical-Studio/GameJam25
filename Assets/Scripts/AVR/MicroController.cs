using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroController : MonoBehaviour
{
	[SerializeField] private bool inColl;

	[SerializeField] private Controller player;
	[SerializeField] private Inventory inv;
	[SerializeField] private GameObject[] modules;
	[SerializeField] private int modulesF;

	void Update(){
		if(Input.GetKeyDown(KeyCode.X) && inColl){
			player.mode = !player.mode;
		}
		if(Input.GetKeyDown(KeyCode.F) && inColl){
			int id = inv.GetHandleItem();
			if(id != -1){
				modules[id].SetActive(true);
				modulesF |= (1 << id);
				inv.DestroyHandleItem();
			}
		} else if(Input.GetKey(KeyCode.G) && inColl){
			for(int i = 0; i < modules.Length; i++){
				
				if((modulesF & (1 << i)) > 0){
					modules[i].SetActive(false);
					//inv.AddItem(i);
					Instantiate(inv.items[i], player.transform.position, Quaternion.identity);
					modulesF &= ~(1 << i);
				}
		
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
