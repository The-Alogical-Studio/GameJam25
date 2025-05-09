using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
	[SerializeField] private Controller player;
	[SerializeField] private Rigidbody rb;
	[SerializeField] private float velocity;
	[SerializeField] private float rY;
	[SerializeField] private Transform controller;
	[SerializeField] private bool flager = true;

	void FixedUpdate(){
		if(Input.GetKeyDown(KeyCode.R)) flager = !flager;
		if(player.mode && flager){
			float Horizontal = Input.GetAxis("Horizontal");
			float Vertical = Input.GetAxis("Vertical") * velocity;
			rY += Horizontal;
			controller.eulerAngles = new Vector3(controller.eulerAngles.x, rY, controller.eulerAngles.z);
			rb.velocity = new Vector3(controller.forward.x * Vertical, rb.velocity.y, controller.forward.z * Vertical);
		}
	}
}
