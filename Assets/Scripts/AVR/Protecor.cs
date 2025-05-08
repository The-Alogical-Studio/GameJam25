using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protecor : MonoBehaviour
{
	[SerializeField] public bool isActive;
	[SerializeField] private MicroController avr;
	[SerializeField] private Rigidbody rb;
	[SerializeField] private float critical;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Ground" && !isActive && rb.velocity.magnitude > critical){
			avr.Break();
		}
	}
}
