using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Awaker : MonoBehaviour
{
	[SerializeField] private AudioSource src;

	public void Awake()
	{
		if(PlayerPrefs.GetInt("Logout") == 1){
			PlayerPrefs.SetInt("Logout", 0);
			StopAllCoroutines();
			Destroy(gameObject);
			return;
		}
		Time.timeScale = 1;
		//StopAllCoroutines();
		StartCoroutine("Waiter");
	}

	public IEnumerator Waiter(){
		yield return new WaitForSeconds(7f);
		Destroy(gameObject);
		src.Play();
	}
}
