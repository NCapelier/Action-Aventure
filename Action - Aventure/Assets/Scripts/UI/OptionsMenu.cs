using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;
using GameSound;

public class OptionsMenu : MonoBehaviour
{
    //[SerializeField] private AudioMixer audioMixer;

    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject shortCutImage;

    [SerializeField] private GameObject pauseButtonReturn;
    [SerializeField] private GameObject allinteractions;

    private void Start()
    {
        //audioMixer = GameSound.AudioManager.Instance.GetComponent<AudioMixer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("B_Button"))
        {
            AudioManager.Instance.Play("Validation_click");
            //pauseButtonReturn.GetComponent<Button>().onClick. blablabla;
        }
    }

    public void Retour()
    {
        AudioManager.Instance.Play("Validation_click");
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
        //Need un Audio Mixer pour que cela marche
        //audioMixer.SetFloat("volume");
    }

    public void SetQuality (int qualityIndex)
    {
        AudioManager.Instance.Play("Validation_click");
        QualitySettings.SetQualityLevel(qualityIndex);
    }

}
