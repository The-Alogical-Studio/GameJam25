using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSaver : MonoBehaviour
{
	[SerializeField] private AndvancedRunner runner;
	[SerializeField] private Slider musicScrollbar;
	[SerializeField] private Slider sfxScrollbar;
	
	public void Awake(){
		HackerSave sv = new HackerSave("settings.json");
		MenuStorage st = sv.readFile(true);

		runner.isEnabled = st.FLAGS;

		Application.targetFrameRate = st.fps;
		Time.fixedDeltaTime = 1f / (float) st.pps;
	
		musicScrollbar.value = st.music;
		sfxScrollbar.value = st.sfx;
	}

	public void Save(){
		MenuStorage st = new MenuStorage();
		st.FLAGS = runner.isEnabled;

		st.fps = (int) (1f / Time.deltaTime);
		st.pps = (int) (1f / Time.fixedDeltaTime);
	
		st.music = musicScrollbar.value;
		st.sfx = sfxScrollbar.value;

		HackerSave sv = new HackerSave("settings.json");
		sv.writeFile(st);
	}
}

public class MenuStorage {
	public float music;
	public float sfx;

	public int fps;
	public int pps;

	public byte FLAGS;
}