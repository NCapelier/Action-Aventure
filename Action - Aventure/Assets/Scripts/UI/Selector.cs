using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Selector : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    [SerializeField] private GameObject ames;

    [Header("Main Menu Buttons")]
    [SerializeField] private GameObject jouer;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject quitter;

   

    private void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == jouer)
        {
            ames.transform.position = waypoints[0].transform.position;
        }
        if (EventSystem.current.currentSelectedGameObject == options)
        {
            ames.transform.position = waypoints[1].transform.position;
        }
        if (EventSystem.current.currentSelectedGameObject == credits)
        {
            ames.transform.position = waypoints[2].transform.position;
        }
        if (EventSystem.current.currentSelectedGameObject == quitter)
        {
            ames.transform.position = waypoints[3].transform.position;
        }
    }

}
