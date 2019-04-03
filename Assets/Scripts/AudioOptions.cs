using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptions : MonoBehaviour
{
    public Toggle musicEnable;
	public Toggle sfxEnable;
    public Slider musicVolume;
    public Slider sfxVolume;
    public AudioClip testSfx;

	private void Start() 
    {
		if (PlayerPrefs.GetInt("MusicEnable") == 1) {
			musicEnable.isOn = true;
            musicVolume.enabled = true;
            musicVolume.value = PlayerPrefs.GetFloat("MusicVolume");
            SoundManager.instance.bgmSource.mute = false;
		} else {
			musicEnable.isOn = false;
            musicVolume.enabled = false;
            SoundManager.instance.bgmSource.mute = true;
		}
		if (PlayerPrefs.GetInt("SfxEnable") == 1) {
			sfxEnable.isOn = true;
            sfxVolume.enabled = true;
            musicVolume.value = PlayerPrefs.GetFloat("SfxVolume");
            SoundManager.instance.sfxSource.mute = false;
		} else {
			sfxEnable.isOn = false;
            sfxVolume.enabled = false;
            SoundManager.instance.sfxSource.mute = true;
		}
	}
	
	private void Update() 
    {
		if (musicEnable.onValueChanged != null) {
			if (musicEnable.isOn) {
				PlayerPrefs.SetInt("MusicEnable", 1);
                SoundManager.instance.bgmSource.mute = false;
			} else {
				PlayerPrefs.SetInt("MusicEnable", 0);
                SoundManager.instance.bgmSource.mute = true;
			}
		}
        if (musicVolume.onValueChanged != null && musicEnable.isOn) {
            PlayerPrefs.SetFloat("MusicVolume", musicVolume.value);
            SoundManager.instance.bgmSource.volume = musicVolume.value / 100;
        } 
		if (sfxEnable.onValueChanged != null) {
			if (sfxEnable.isOn) {
				PlayerPrefs.SetInt("SfxEnable", 1);
                SoundManager.instance.sfxSource.mute = false;
			} else {
				PlayerPrefs.SetInt("SfxEnable", 0);
                SoundManager.instance.sfxSource.mute = true;
			}
		}
        if (sfxVolume.onValueChanged != null && sfxEnable.isOn) {
            PlayerPrefs.SetFloat("SfxVolume", sfxVolume.value);
            SoundManager.instance.sfxSource.volume = sfxVolume.value / 100;
        }
	}


}
