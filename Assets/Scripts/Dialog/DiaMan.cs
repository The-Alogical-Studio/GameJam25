using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaMan : MonoBehaviour
{
	[SerializeField] private bool inColl;
	[SerializeField] private bool inDia;
	[SerializeField] private Dialog[] dia;
	[SerializeField] private string name;

	[SerializeField] private int seq;
	[SerializeField] private int rep;

	[SerializeField] private Text nameText;
	[SerializeField] private Text diaText;
	[SerializeField] private GameObject diaBlock;

	void Update(){
		if(Input.GetKeyDown(KeyCode.C) && inColl){
			if(seq == dia[rep].text.Length){
				NextRepclica();
				diaBlock.SetActive(false);
				inDia = !inDia;
				return;
			}
			if(!inDia) {
				diaBlock.SetActive(true);
				inDia = !inDia;
			} 
			nameText.text = name;
			diaText.text = dia[rep].text[seq];
			seq += 1;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			inColl = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			inColl = false;
		}
	}

	public void NextRepclica(){
		rep += 1;
		seq = 0;
	}
}

[System.Serializable]
public class Dialog {
	[TextArea(3, 10)] public string[] text;
}
