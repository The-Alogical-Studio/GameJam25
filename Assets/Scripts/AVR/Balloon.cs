using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
	[SerializeField] private Controller con;
	[SerializeField] private Transform body;
	[SerializeField] private Rigidbody rb;
	[SerializeField] private float velocity;
	[SerializeField] private bool isFly;

	void Update(){
		if(con.mode){
			if(Input.GetKeyDown(KeyCode.R)){
				isFly = !isFly;
			}

			if(isFly){
				float hor = Input.GetAxis("Horizontal") * 5;
				float ver = Input.GetAxis("Vertical") * 5;
				body.eulerAngles = new Vector3(ver, 0, hor);
				rb.velocity = new Vector3(hor, 1, ver) * velocity;
			}
		}
	}
}
