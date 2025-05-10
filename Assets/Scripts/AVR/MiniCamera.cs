using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamera : MonoBehaviour
{
	[SerializeField] private Controller player;
	[SerializeField] private GameObject cam1;
	[SerializeField] private GameObject cam2;
	[SerializeField] private float scaleMap;
	[SerializeField] private Camera there;
	[SerializeField] private bool flag;
	
	void Update(){
		if(flag == !player.mode){
			flag = !flag;
			cam1.SetActive(flag);
			cam2.SetActive(!flag);
		}
		scaleMap += Input.mouseScrollDelta.y * 2;
		there.fieldOfView = scaleMap;
	}
}
