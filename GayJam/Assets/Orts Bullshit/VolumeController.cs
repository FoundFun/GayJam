using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixerGroup Mixer;

    public void ChangeMasterVolume(float volume)
    {
        Mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-40,0,volume));
    }

    public void ChangeFXVolume(float volume)
    {
        Mixer.audioMixer.SetFloat("FXVolume", Mathf.Lerp(-40, 0, volume));
    }

    public void ChangeMusicVolume(float volume)
    {
        Mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-40, 0, volume));
    }
}
