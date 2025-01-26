using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumnScript : MonoBehaviour
{
    //public Slider slider;
    //public float sliderValue;
    //public Image imagenMute;
    //public AudioMixer audioMixer; // Asignar el Audio Mixer desde el Inspector

    //void Start()
    //{
    //    slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
    //    audioMixer.SetFloat("musicVolume", Mathf.Log10(slider.value) * 20); // Logarítmico
    //    IsMute();
    //}

    //public void ChangeSlider(float value)
    //{
    //    sliderValue = value;
    //    PlayerPrefs.SetFloat("volumenAudio", sliderValue);
    //    audioMixer.SetFloat("musicVolume", Mathf.Log10(slider.value) * 20); // Logarítmico
    //    IsMute();
    //}

    //public void IsMute()
    //{
    //    if (sliderValue == 0)
    //    {
    //        imagenMute.enabled = true;
    //    }
    //    else
    //    {
    //        imagenMute.enabled = false;
    //    }
    //}

    public Slider slider;           // Slider para controlar volumen
    public Image imagenMute;        // Imagen de mute
    public AudioMixer audioMixer;   // AudioMixer desde el Inspector

    private bool isMuted;   // Estado de mute

    void Start()
    {
        // Cargar el volumen guardado previamente o 0.5 como valor por defecto
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);

        // Configurar el volumen de la música
        audioMixer.SetFloat("musicVolume", Mathf.Log10(slider.value) * 20);

        // Comprobar si está silenciado
        isMuted = PlayerPrefs.GetInt("IsMuted", 0) == 1;
        UpdateMuteState();
    }

    // Cambiar volumen de la música
    public void ChangeSlider(float value)
    {
        // Cambiar el volumen de la música en el Audio Mixer
        audioMixer.SetFloat("musicVolume", Mathf.Log10(value) * 20);

        // Guardar volumen en PlayerPrefs
        PlayerPrefs.SetFloat("volumenAudio", value);

        // Actualizar el estado de mute
        UpdateMuteState();
    }

    // Actualizar el estado del mute
    public void ToggleMute(bool muteState)
    {
        isMuted = muteState;
        PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);
        UpdateMuteState();
    }

    // Actualizar mute o volumen
    private void UpdateMuteState()
    {
        if (isMuted)
        {
            // Silenciar todo
            audioMixer.SetFloat("musicVolume", -80); // Mute música
        }
        else
        {
            // Restaurar volumen de música
            audioMixer.SetFloat("musicVolume", Mathf.Log10(slider.value) * 20);
        }

        // Cambiar la imagen de mute
        imagenMute.enabled = isMuted;
    }
}
