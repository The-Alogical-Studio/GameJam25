using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveEngine : MonoBehaviour
{
	[SerializeField] private Controller con;
	[SerializeField] private Transform body;
	[SerializeField] private Rigidbody rb;
	[SerializeField] private float rX, rY, velocity;
	[SerializeField] private bool isFly;

	void Update(){
		if(con.mode){
			if(Input.GetKeyDown(KeyCode.R)){
				isFly = !isFly;
			}

			if(isFly){
				rX -= Input.GetAxis("Vertical");
				rY += Input.GetAxis("Horizontal");
				body.eulerAngles = new Vector3(rX, rY, 0);;
				rb.velocity = body.forward * velocity;
			}
		}
	}
}
