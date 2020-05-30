using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject playButton;

    public void Retour()
    {
        EventSystem.current.SetSelectedGameObject(playButton);
    }
}
