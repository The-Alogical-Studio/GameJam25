using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	[SerializeField] private GameObject projectTile;
	[SerializeField] private MenuLister ml;
	[SerializeField] private float millis;
	[SerializeField] private Controller player;

	void Update(){
		if(player.mode) {
			millis += Time.deltaTime;
			if(Input.GetMouseButtonDown(0) && (ml.flag & 1) == 0){
				Instantiate(projectTile, transform.position + transform.forward * 1, Quaternion.Euler(transform.eulerAngles)).GetComponent<Rigidbody>().velocity = transform.forward * 20;
			}
			if(Input.GetMouseButton(0) && millis >= 0.25f){
				millis = 0;		
				Instantiate(projectTile, transform.position + transform.forward * 1, Quaternion.Euler(transform.eulerAngles)).GetComponent<Rigidbody>().velocity = transform.forward * 20;		
			}
		}
	}
}
