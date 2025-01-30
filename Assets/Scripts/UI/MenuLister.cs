using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLister : MonoBehaviour
{
	[SerializeField] private GameObject menu;
	[SerializeField] private GameObject settings;
	[SerializeField] private GameObject saveLoad;
	[SerializeField] private byte flag;

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			if((flag & 1) == 1){
				Time.timeScale = 1;
			} else {
				Time.timeScale = 0.00001f;
			}
			menu.SetActive((flag & 1) == 1 ? false : true);
			if((flag & 1) == 1){
				flag = (byte) ((sbyte) ~1 & flag);
			} else {
				flag |= 1;
			}
		}
	}

	public void SettingsDisplay(){
		settings.SetActive((flag & 2) == 2 ? false : true);
		if((flag & 2) == 2){
			flag = (byte) ((sbyte) ~2 & flag);
		} else {
			flag |= 2;
		}
	}

	public void SaveLoadDisplay(){
		saveLoad.SetActive((flag & 4) == 4 ? false : true);
		if((flag & 4) == 4){
			flag = (byte) ((sbyte) ~4 & flag);
		} else {
			flag |= 4;
		}
	}
}
