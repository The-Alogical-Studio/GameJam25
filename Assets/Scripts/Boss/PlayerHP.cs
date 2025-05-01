using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
	[SerializeField] private int heal = 20;
	private float tmr;

	public void Damage(int hp){
		heal -= hp;
	}

	void Update(){
		tmr += Time.deltaTime;
		if(heal < 20 && tmr >= 2f){
			heal += 1;
			tmr = 0;
		}
	}
}
