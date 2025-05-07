using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
	[SerializeField] private int levelToLoad;
	[SerializeField] private GameObject gm;
	[SerializeField] private Animator an;

	public void LDS()
	{
		Time.timeScale = 1;
		StopAllCoroutines();
		gm.SetActive(true);
		an.SetTrigger("Next");
		StartCoroutine("Waiter");

	}

	public IEnumerator Waiter(){
		yield return new WaitForSeconds(0.5f);
		PlayerPrefs.SetInt("Logout", 1);
		SceneManager.LoadScene(levelToLoad);
	}
}
