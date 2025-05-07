using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiter : MonoBehaviour
{
	[SerializeField] private bool flag;
	[SerializeField] private Animator gm;

	public void Quit(){
		Application.Quit();
	}

	public void AboutInverse(){
		flag = !flag;
		gm.SetBool("ab", flag);
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape) && flag){
			AboutInverse();
		}
	}
}
