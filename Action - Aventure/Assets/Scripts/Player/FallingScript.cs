using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class FallingScript : MonoBehaviour
{
    public GameObject respawnPoint;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerController")
        {
            Debug.Log("Started");
            StartCoroutine("Falling");
          
        }
    }

    IEnumerator Falling()
    {
        //Stopper le player
        yield return new WaitForSeconds(0.5f);
        //Jouer l'anim de chute
        //Faire prendre des dégats
        PlayerManager.Instance.gameObject.transform.position = respawnPoint.transform.position;
        //Déclencher invincibilité
    }
}
