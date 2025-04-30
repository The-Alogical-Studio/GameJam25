using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	[SerializeField] private bool flag;
	[SerializeField] private int id;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player" && !flag){
			other.GetComponent<Inventory>().AddItem(id);
			flag = false;
			Destroy(gameObject);
			return;
		}
	}
}
