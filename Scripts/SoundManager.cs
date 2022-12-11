using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sndMan;
    
    private AudioSource audioSrc;
    private AudioClip coinSound;
    private AudioClip jumpSound;
    private AudioClip explosionSound;
    // Start is called before the first frame update
    void Start()
    {
        sndMan = this;
        audioSrc = GetComponent<AudioSource>();
        coinSound = Resources.Load<AudioClip>("Sounds/pickupCoin");
        jumpSound = Resources.Load<AudioClip>("Sounds/blipSelect");
        explosionSound = Resources.Load<AudioClip>("Sounds/explosion");
    }

    // Update is called once per frame
    public void PlayCoin()
    {
        audioSrc.PlayOneShot(coinSound);
        
    }

    public void Jump()
    {
        audioSrc.PlayOneShot(jumpSound);
    }

    public void Hit()
    {
        audioSrc.PlayOneShot(explosionSound);
    }
}


