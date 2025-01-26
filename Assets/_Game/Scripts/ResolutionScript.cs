using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionScript : MonoBehaviour
{
    public Dropdown resolutionDropDown;
    Resolution[] resolutions;

    void Start()
    {
        ReviseResolution();
    }

    public void ActiveFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void ReviseResolution()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> Options = new List<string>();
        int ResolutionActualy = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string Option = resolutions[i].width + " x " + resolutions[i].height;
            Options.Add(Option);

            if(Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                ResolutionActualy = i;
            }
        }
        resolutionDropDown.AddOptions(Options);
        resolutionDropDown.value = ResolutionActualy;
        resolutionDropDown.RefreshShownValue();
        
        
        resolutionDropDown.value = PlayerPrefs.GetInt("numeroResolucion", 0);
    }


    public void ChangeResolution(int indexResolution)
    {
        PlayerPrefs.SetInt("numeroResolucion", indexResolution); // Guardar correctamente
        PlayerPrefs.Save(); // Asegurarse de guardar los cambios

        Resolution resolution = resolutions[indexResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
