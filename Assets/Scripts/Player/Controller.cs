using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	[SerializeField] private Rigidbody rb;
	[SerializeField] private Transform cam;
	[SerializeField] private float velocity = 1f;
	[SerializeField] private float sens = 100f;
	[SerializeField] private float jf;

	private float ry;
	private float rx;

	void Awake(){
		rb = GetComponent<Rigidbody>();
		cam = transform.GetChild(0);
	}

	void FixedUpdate(){
		ry += Input.GetAxis("Mouse X") * sens;
		rx -= Input.GetAxis("Mouse Y") * sens;
		cam.eulerAngles = new Vector3(rx, ry, 0);
		rb.velocity = Quaternion.Euler(new Vector3(0, cam.eulerAngles.y, 0)) * new Vector3(Input.GetAxis("Horizontal") * velocity, rb.velocity.y, Input.GetAxis("Vertical") * velocity);

		if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
			rb.AddForce(new Vector3(0, jf, 0));
		}
	}

	public bool IsGrounded() {
		RaycastHit hit;
		float rayLength = 1; // Adjust based on your character's size
		if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength)) {
			return true;
		}
		return false;
	}
}
