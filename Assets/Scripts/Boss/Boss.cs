using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
	[SerializeField] private PlayerHP player;
	[SerializeField] private int health;
	[SerializeField] private NavMeshAgent agent;
	[SerializeField] private Slider sld;

	void Update(){
		agent.destination = player.transform.position;
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "PBull"){
			health -= 1;
			sld.value = health;
			Destroy(other.gameObject);
			if(health <= 0){
				Destroy(gameObject);
			}
		}
	}
}
