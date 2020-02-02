using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundController : MonoBehaviour {

    public AudioClip soundClip;
    public AudioClip failClip;
    public AudioSource soundSource;


	// Use this for initialization
	void Start () 
    {
        soundSource.clip = soundClip;
	}
	
	// Update is called once per frame
    public void playSuccessSound()
    {
        soundSource.clip = soundClip;
        soundSource.Play();
    }

    public void playFailSound()
    {
        soundSource.clip = failClip;
        soundSource.Play();
    }
}
