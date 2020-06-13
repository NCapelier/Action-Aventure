using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;
using UnityEngine.EventSystems;
using Management;
using UnityEngine.SceneManagement;
using Player;


public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject backGround;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject particule1;
    [SerializeField] private GameObject particule2;
    [SerializeField] private GameObject personnage;
    [SerializeField] private Button quitter;
    [SerializeField] private Button menu;
    [SerializeField] private Canvas canvas;
    [SerializeField] private EventSystem eventS;
    
   

    [SerializeField] private bool trigger;
    [SerializeField] private bool triggerOnce = false;

    private void Update()
    {
        if(GameManager.Instance.gameState.playerDead == true && triggerOnce == false)
        {
  
            StartCoroutine("appering");
        }
    }

    public void Death()
    {
        PlayerManager.Instance.controller.isDialoging = false;
        GameManager.Instance.gameState.playerDead = true;
        SuperGameManager.Instance.DestroyAllGameObjects();
        SceneManager.LoadScene("0_MainMenu");
    }

    public void Quitter()
    {
        AppHelper.Quit();
    }

    IEnumerator appering()
    {
        PlayerManager.Instance.controller.isDialoging = true;
        
        if(triggerOnce == true)
        {
            yield return null;
        }
        else if (triggerOnce == false)
        {
            triggerOnce = true;

            
            canvas.gameObject.SetActive(true);
            backGround.SetActive(true);
            title.SetActive(true);
            particule2.SetActive(true);
            particule1.SetActive(true);
            personnage.SetActive(true);
            yield return new WaitForSeconds(4f);
            quitter.gameObject.SetActive(true);
            menu.gameObject.SetActive(true);
            eventS.gameObject.SetActive(true);
            Debug.Log("trigger");
            yield return null;
        }
        
    }
}
