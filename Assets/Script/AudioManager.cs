using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : GenericSingletonPersistant<AudioManager>
{
    public AudioSource audio;
    public AudioClip comer;
    public override void Awake()
    {
        base.Awake();
    }
    public void PlayAudio()
    {
        audio.Play();
    }
    public void ChargePlay()
    {
        SceneManager.LoadScene(1);
    }
}
