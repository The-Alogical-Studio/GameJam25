using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LegacyDrop : MonoBehaviour
{
	[SerializeField] private Button toggled;
	[SerializeField] private byte mode;
	[SerializeField] private string st;

	void Awake(){
		using (StreamReader sr = new StreamReader("./GameName.json"))
        {
            string s = sr.ReadLine();
            Filecat data = JsonUtility.FromJson<Filecat>(s);
            Transform par = transform.GetChild(0).GetChild(0);
            for(int i = 0; i < data.st.Length; i++){
				par.GetChild(i).GetChild(2).GetComponent<Text>().text = data.st[i];
            }
        }
	}

	void Update(){
		if(mode == 1){
			if(Input.GetKeyDown(KeyCode.Backspace)){
				st = st.Remove(st.Length - 1, 1);
				toggled.transform.GetChild(2).GetComponent<Text>().text = st;
 			}
			for (int i = 0; i <= 27; i++){
				if (Input.GetKeyDown(KeyCode.A + i)){
					char cs = (char) (((byte) i) + 'A');
					st += cs;
					toggled.transform.GetChild(2).GetComponent<Text>().text = st;
					return;
				}
			}
			if(Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)){
				mode = 0;
				toggled.transform.GetChild(2).GetComponent<Text>().text = st;
				st = "";
				using (StreamWriter sw = new StreamWriter("./GameName.json"))
				{
					Transform par = transform.GetChild(0).GetChild(0);
					string[] strst = new string[par.childCount]; 
					for(int i = 0; i < par.childCount; i++){
						strst[i] = par.GetChild(i).GetChild(2).GetComponent<Text>().text;
					}
					sw.WriteLine(JsonUtility.ToJson(new Filecat(strst)));
				}
				return;
			}

		}
	}

	public void Tog(Button self){
		if(toggled.transform.name == self.transform.name) {
			Interput();
			return;
		}
		toggled.transform.GetChild(1).gameObject.SetActive(false);
		self.transform.GetChild(1).gameObject.SetActive(true);
		toggled = self;
	}

	public int getToggleId(){
		char id = toggled.transform.name[toggled.transform.name.Length - 1];
		return id - '0';
	}

	public void Interput(){
		mode = 1;
		return;
	}
}


public struct Filecat {
	public string[] st;

	public Filecat(string[] str){
		this.st = str;
	}
}
