using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvTaker : MonoBehaviour
{
	[SerializeField] private Transform toHit;
	[SerializeField] private Transform hit;
	[SerializeField] private bool taken;
	[SerializeField] private bool inColl;

	void Update(){
		if(Input.GetKeyDown(KeyCode.E) && inColl && !taken){
			taken = !taken;
		}
		if(Input.GetKeyDown(KeyCode.Q) && taken){
			taken = !taken;
		}

		if(taken){
			toHit.position = hit.position;
		}

	}

	void OnTriggerEnter(Collider other){
		if(taken) return;
		toHit = other.transform;
		inColl = true;
	}
	void OnTriggerExit(Collider other){
		if(taken) return;
		inColl = false;
	}
}
