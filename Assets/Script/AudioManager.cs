using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : GenericSingletonPersistant<AudioManager>
{
    public AudioSource audio;
    public override void Awake()
    {
        base.Awake();
    }
    public void PlayAudio(AudioClip comer)
    {
        audio.PlayOneShot(comer);
        
    }
    public void ChargePlay()
    {
        SceneManager.LoadScene(1);
    }
}
