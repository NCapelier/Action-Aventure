using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using GameSound;

public class MainMenu : MonoBehaviour
{
    [Header("OptionsReference")]
    [SerializeField] public static GameObject returnButton;
    [SerializeField] private GameObject allInteractions;

    [Header("Credits")]
    [SerializeField] private GameObject creditsPack;
    [SerializeField] private GameObject creditsButton;

    public void PlayGame()
    {
        AudioManager.Instance.Play("Validation_click");
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        AudioManager.Instance.Play("Validation_click");
        Debug.Log("Quitter");
        AppHelper.Quit();
    }

    public void Options()
    {
        AudioManager.Instance.Play("Validation_click");
        allInteractions.SetActive(true);
        EventSystem.current.SetSelectedGameObject(returnButton);
    }

    public void Credits()
    {
        AudioManager.Instance.Play("Validation_click");
        creditsPack.SetActive(true);
        EventSystem.current.SetSelectedGameObject(creditsButton);
    }
}
