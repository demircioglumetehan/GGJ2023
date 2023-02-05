using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : Singleton<Audiomanager>
{
    private AudioSource source;
    [SerializeField]private AudioClip turnClip;
    void Start()
    {
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }
    public void PlayTurnSound()
    {
        source.PlayOneShot(turnClip);

    }
}
