using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ResolutionGeneration : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdownMenu;

    public AudioMixer VolumeMixer;

    public Slider s1;
    public Slider s2;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private float currRefreshRate;
    private int currResolutionIdx = 0;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resolutionDropdownMenu.ClearOptions();
        currRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++) {
            if (resolutions[i].refreshRate == currRefreshRate) {
                filteredResolutions.Add(resolutions[i]);
            }
        }
        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string resOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + " Hz";
            options.Add(resOption);
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currResolutionIdx = i;
            }
        }
        resolutionDropdownMenu.AddOptions(options);
        resolutionDropdownMenu.value = currResolutionIdx;
        resolutionDropdownMenu.RefreshShownValue();

        //Debug.Log("setting volume init value to " + PlayerPrefs.GetFloat("VolumeValue").ToString());
        s1.value = PlayerPrefs.GetFloat("GeneralVolumeValue");
        s2.value = PlayerPrefs.GetFloat("EffectsVolumeValue");
    }

    // Update is called once per frame
    public void setRes(int resIdx)
    {
        Resolution res = filteredResolutions[resIdx];
        Screen.SetResolution(res.width, res.height, true);
        //Debug.Log("res set");
    }

    public void setFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
        //Debug.Log("set to fullscreen");
    }

    public void setGeneralVolume(float volume)
    {
        VolumeMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("GeneralVolumeValue", volume);
        //Debug.Log(PlayerPrefs.GetFloat("VolumeValue"));
    }

    public void setEffectsVolume(float volume)
    {
        
        PlayerPrefs.SetFloat("EffectsVolumeValue", volume);
        //Debug.Log(PlayerPrefs.GetFloat("VolumeValue"));
    }

    public void rebindKeys() {
        SceneManager.LoadScene("KeyRebind");
    }
    public void ReturnToMain(){
        SceneManager.LoadScene("MainMenu");
    }
}
