using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicMan : MonoBehaviour
{
	[SerializeField] private AudioSource[] SFX;
	[SerializeField] private AudioSource[] music;

	[SerializeField] private Slider musicScrollbar;
	[SerializeField] private Slider sfxScrollbar;

	public void ISCRm(){
		foreach(AudioSource msc in music){
			msc.volume = musicScrollbar.value;
		}
	}

	public void ISCRs(){
		foreach(AudioSource sf in SFX){
			sf.volume = sfxScrollbar.value;
		}
	}
}
