using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
	[SerializeField] private Transform body;
	[SerializeField] private Controller player;

	void Update(){
		if(player.mode){
			if(Input.GetKeyDown(KeyCode.Z)){
				body.eulerAngles = new Vector3(0, body.eulerAngles.y, 0);
			}
		}
	}
}
