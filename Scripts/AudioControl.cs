using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class AudioControl : MonoBehaviour
{
    public AudioClip otherClip;
    AudioSource audio;
    public IEnumerator Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = otherClip;
        audio.Play();
    }

    public void Jump()
    {

    }

    public void Hit()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }

    public void Coin()
    {
        AudioSource audio = GetComponent<AudioSource>();
        Debug.Log("COIN SOUND");
        audio.Play();
        
    }
}