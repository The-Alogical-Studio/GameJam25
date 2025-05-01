//Hacker lib for unity
//HackerBlock
//Works only with HackerInventory

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackerBlock : MonoBehaviour
{
	[SerializeField] private KeyCode code = KeyCode.E;
	[SerializeField] private int MouseButton;

	// flag description
	// 1st bit - inColl
	// 2nd bit - is mouse event (0 - keypad; 1 - mouse)
	// 3rd bit - is inventory item need
	// 4th bit - is inventory set item (0 - instantiate object; 1 - send to inventory item)
	// 5th bit - is need to destroy prev item object
	[SerializeField] private byte flags;

	[SerializeField] private Inventory player;
	[SerializeField] private int idCheck;
	[SerializeField] private int idDrop;
	[SerializeField] private GameObject prefab;

	void Update(){
		if((flags & 1) == 1 && ((((flags & 2) == 2) && Input.GetMouseButtonDown(MouseButton)) || (((flags & 2) == 0) && Input.GetKeyDown(code)))) {
			if((flags & 4) == 4 && player.HandleItem(idCheck)){
				if((flags & 8) == 8){
					if((flags & 16) == 16){
						player.DestroyHandleItem();
					}
					player.AddItem(idDrop);
				} else {
					if((flags & 16) == 16){
						player.DestroyHandleItem();
					}
					Object.Instantiate(prefab, transform.position + Vector3.up * 2, Quaternion.identity);
				}
			} else if((flags & 4) == 0){
				if((flags & 8) == 8){
					player.AddItem(idDrop);
				} else {
					Object.Instantiate(prefab, transform.position + Vector3.up * 2, Quaternion.identity);
				}
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			flags = (byte) (flags | 1);
			player = other.GetComponent<Inventory>();
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			flags = (byte) (flags & 254);
		}
	}
}
