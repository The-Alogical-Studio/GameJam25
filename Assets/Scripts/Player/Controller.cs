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
	[SerializeField] private GameObject sound;
	[SerializeField] private AudioSource jump;
	[SerializeField] private byte FLAGS;

	public bool mode;

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
		if(mode) return;
		rb.velocity = Quaternion.Euler(new Vector3(0, cam.eulerAngles.y, 0)) * new Vector3(Input.GetAxis("Horizontal") * velocity, rb.velocity.y, Input.GetAxis("Vertical") * velocity);
		if((FLAGS & 1) == 0 && rb.velocity != new Vector3(0f, rb.velocity.y, 0f)){
			FLAGS = (byte) (FLAGS | 1);
			sound.SetActive(true);
		} else if((FLAGS & 1) == 1 && rb.velocity == new Vector3(0f, rb.velocity.y, 0f)){
			FLAGS = (byte) (FLAGS & 254);
			sound.SetActive(false);
		}

		if(Input.GetKey(KeyCode.Space) && IsGrounded()){
			rb.AddForce(new Vector3(0, jf, 0));
			jump.Play();
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
