using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamera : MonoBehaviour
{
	[SerializeField] private Controller player;
	[SerializeField] private GameObject cam1;
	[SerializeField] private GameObject cam2;

	[SerializeField] private bool flag;
	
	void Update(){
		if(flag == !player.mode){
			flag = !flag;
			cam1.SetActive(flag);
			cam2.SetActive(!flag);
		}
	}
}
