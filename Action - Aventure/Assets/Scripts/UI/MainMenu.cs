using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [Header("OptionsReference")]
    [SerializeField] private GameObject returnButton;
    [SerializeField] private GameObject allInteractions;

    [Header("Credits")]
    [SerializeField] private GameObject creditsPack;
    [SerializeField] private GameObject creditsButton;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitter");
        AppHelper.Quit();
    }

    public void Options()
    {
        allInteractions.SetActive(true);
        EventSystem.current.SetSelectedGameObject(returnButton);
    }

    public void Credits()
    {
        creditsPack.SetActive(true);
        EventSystem.current.SetSelectedGameObject(creditsButton);
    }
}
