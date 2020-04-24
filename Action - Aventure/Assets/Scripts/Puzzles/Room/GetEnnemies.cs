using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnnemies : MonoBehaviour
{
    private List<GameObject> enemyInThisRoom;
    public GameObject door;
    public bool ennemyhere;

    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(false);
        ennemyhere = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ennemyhere == true)
        {
            if (enemyInThisRoom.Count == 0)
            {
                door.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyInThisRoom.Add(collision.gameObject);
            ennemyhere = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyInThisRoom.Remove(collision.gameObject);
        }
    }
}
