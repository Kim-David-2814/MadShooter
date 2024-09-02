using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSoundComponent : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip _click;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void OnClickSounfButton()
    {
        _audio.PlayOneShot(_click);
    }
}
