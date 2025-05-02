using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPU : MonoBehaviour
{
	public void FPSMax(InputField fd){

		int fps = int.Parse(fd.text);
		Application.targetFrameRate = fps;
	} 

	public void FixedMax(InputField fd){
		int fps = int.Parse(fd.text);
		//Debug.Log(1 / (float) fps);
		//Debug.Log(fps);
		Time.fixedDeltaTime = 1 / (float) fps;
	} 

	public void Update(){
		//Debug.Log(1 / Time.fixedDeltaTime);
	}
}
