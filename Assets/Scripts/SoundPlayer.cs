using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip unlockSound;
    public AudioClip buildSound;
    public AudioClip wrongSound;
    public AudioClip coinSound;

    private void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        GameEvents.current.onNodeUnlock += PlayUnlockSound;
        GameEvents.current.onBuildCountChange += PlayBuildSound;
        GameEvents.current.onWrongDisplay += PlayWrongSound;
        GameEvents.current.onCoinCountChange += PlayCoinSound;
    }

    private void PlayCoinSound(int obj)
    {
        if (obj > 0)
        {
            _audioSource.clip = coinSound;
            _audioSource.PlayOneShot(_audioSource.clip);
        }
        
    }

    private void PlayUnlockSound(int x, int y,int count)
    {
        _audioSource.clip = unlockSound;
        _audioSource.PlayOneShot(_audioSource.clip);
    }

    private void PlayBuildSound(int count)
    {
        _audioSource.clip = buildSound;
        _audioSource.PlayOneShot(_audioSource.clip);
    }

    private void PlayWrongSound()
    {
        _audioSource.clip = wrongSound;
        _audioSource.PlayOneShot(_audioSource.clip);
    }
}
