using UnityEngine;

public class SoundEfectBtn : MonoBehaviour
{
    private AudioSource music;
    public AudioClip clickAudio;
    public AudioClip switchAudio;

    public void Start()
    {
        music = GetComponent<AudioSource>();    
    }

    public void ClickAudioOn()
    {
        music.PlayOneShot(clickAudio);
    }

    public void SwitchAudio()
    {
        music.PlayOneShot(switchAudio);
    }

}
