using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject shortCutImage;

    [SerializeField] private GameObject pauseButtonReturn;

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
}
