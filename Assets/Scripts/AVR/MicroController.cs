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
	[SerializeField] private Protecor prot;

	[SerializeField] private float[] capacity;
	public float capacitor = 100f;

	void Update(){
		if(Input.GetKeyDown(KeyCode.X) && inColl){
			player.mode = !player.mode;
		}
		if(Input.GetKeyDown(KeyCode.F) && inColl){
			int id = inv.GetHandleItem();
			if(id != -1){
				if(capacitor - capacity[id] < 0) return;
				capacitor -= capacity[id];
				modules[id].SetActive(true);
				modulesF |= (1 << id);
				inv.DestroyHandleItem();
				if(id == 7){
					prot.isActive = true;
				} else if(id == 8){
					capacitor += 100;
				}
			}
		} else if(Input.GetKey(KeyCode.G) && inColl){
			Break();
		}
	}

	public void Break(){
		for(int i = 0; i < modules.Length; i++){
				
			if((modulesF & (1 << i)) > 0){
				modules[i].SetActive(false);
				//inv.AddItem(i);
				Instantiate(inv.items[i], player.transform.position, Quaternion.identity);
				modulesF &= ~(1 << i);
			}
	
		}
		prot.isActive = false;
		player.mode = false;
		player.transform.GetChild(0).gameObject.SetActive(true);
		capacitor = 100f;
	}

	void OnTriggerEnter(Collider other){
		inColl = true;
	}
	
	void OnTriggerExit(Collider other){
		inColl = false;
	}

	public int GetMod() {return modulesF;}
	public void SetMod(int mod) {modulesF = mod;}
}
