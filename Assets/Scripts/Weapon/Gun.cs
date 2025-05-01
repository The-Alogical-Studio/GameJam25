using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	[SerializeField] private GameObject projectTile;
	[SerializeField] private MenuLister ml;

	void Update(){
		if(Input.GetMouseButtonDown(0) && (ml.flag & 1) == 0){
			Instantiate(projectTile, transform.position + transform.forward * 1, Quaternion.Euler(transform.eulerAngles)).GetComponent<Rigidbody>().velocity = transform.forward * 20;
		}
	}
}
