using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndvancedRunner : MonoBehaviour
{
	[SerializeField] private Text FPS;
	[SerializeField] private Text POS;
	[SerializeField] private Text tmr;
	[SerializeField] private byte isEnabled;
	[SerializeField] private float FPfil;
	[SerializeField] private Transform player;
	[SerializeField] private float secs;

	void Update(){
		if(Time.timeScale == 1){
			if((isEnabled & 1) == 1){
				FPfil += ((1 / Time.deltaTime) - FPfil) * 0.05f;
				FPS.text = $"FPS: {FPfil}";
			}
			if((isEnabled & 2) == 2){
				POS.text = $"POS: {player.position}";
			}
			if((isEnabled & 4) == 4){
				secs += Time.deltaTime;
				tmr.text = $"Time {((int) secs/3600)}/{((int) secs / 60) % 60}/{(int)secs%60}";
			}
		}

	}

	public void SetFlag(int number){
		byte con = (byte) (1 << number); 
		if((isEnabled & con) == con){
			isEnabled = (byte) (isEnabled & ((sbyte) ~con)); 
		} else {
			isEnabled = (byte) (isEnabled | con);
		}

		switch(number){
			case 0:
				FPS.gameObject.SetActive((isEnabled & con) == con ? true : false);
				break;
			case 1:
				POS.gameObject.SetActive((isEnabled & con) == con ? true : false);
				break;
			case 2:
				tmr.gameObject.SetActive((isEnabled & con) == con ? true : false);
				break;
		}
	}
}
