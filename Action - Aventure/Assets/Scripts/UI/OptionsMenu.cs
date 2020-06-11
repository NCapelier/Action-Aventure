using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;
using GameSound;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    //[SerializeField] private AudioMixer audioMixer;

    public AudioMixer audioMixer;

    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject shortCutImage;

    [SerializeField] private GameObject pauseButtonReturn;
    [SerializeField] private GameObject allinteractions;
    
    //Quality;
    public TMPro.TMP_Dropdown dropDown;
    public int qualityIndex;

    //resolutions
    Resolution[] resolutions;
    public TMP_Dropdown dropDownRes;
    public int currentResolutionIndex = 0;

    private void Start()
    {
        resolutions = Screen.resolutions;

        dropDownRes.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        dropDownRes.AddOptions(options);
        dropDownRes.value = currentResolutionIndex;
        dropDownRes.RefreshShownValue();
        //audioMixer = GameSound.AudioManager.Instance.GetComponent<AudioMixer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("B_Button"))
        {
            AudioManager.Instance.Play("Validation_click");
            //pauseButtonReturn.GetComponent<Button>().onClick. blablabla;
        }
        qualityIndex = dropDown.value;
        QualitySettings.SetQualityLevel(qualityIndex, true);
    }

    public void Retour()
    {
        AudioManager.Instance.Play("Validation_click");
        EventSystem.current.SetSelectedGameObject(playButton); 
       EventSystem.current.SetSelectedGameObject(playButton); 
    }

    public void ShortCut()
    {
        AudioManager.Instance.Play("Validation_click");
        shortCutImage.SetActive(true);
        allinteractions.SetActive(false);
    }

    public void Quitter()
    {
        AudioManager.Instance.Play("Validation_click");
        Debug.Log("Quitter");
        AppHelper.Quit();
    }

    public void FullScreen(bool isFullScreen)
    {

        Screen.fullScreen = isFullScreen;
        
        
    }

    public void SetVolume (float volume)
    {
        
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        AudioManager.Instance.Play("Validation_click");
        QualitySettings.SetQualityLevel(qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex, true);
    }

    public void SetResolution(int resolututionindex)
    {
        Resolution resolution = resolutions[resolututionindex];
       
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
