using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    //[SerializeField] private AudioMixer audioMixer;

    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject shortCutImage;

    [SerializeField] private GameObject pauseButtonReturn;

    private void Start()
    {
        //audioMixer = GameSound.AudioManager.Instance.GetComponent<AudioMixer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("B_Button"))
        {
            //pauseButtonReturn.GetComponent<Button>().onClick. blablabla;
        }
    }

    public void Retour()
    {
            EventSystem.current.SetSelectedGameObject(playButton); 
    }

    public void ShortCut()
    {
        shortCutImage.SetActive(true);
    }

    public void Quitter()
    {
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
        QualitySettings.SetQualityLevel(qualityIndex);
    }

}
