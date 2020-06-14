using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSound;
using Player;

public class LifePack : MonoBehaviour
{
    private bool isDrop;
    private bool isPickUp;
    private float floatingEffect = 0f;
    [Header("Variables")]
    [Range(0.1f, 10f)]
    public float lifeTime;
    public float warningTime;

    private Animator lifeCoinAnim;

    // Start is called before the first frame update
    void Start()
    {
        lifeCoinAnim = GetComponent<Animator>();
        lifeCoinAnim.enabled = false;
        isDrop = true;
        isPickUp = false;
        StartCoroutine("Timelife");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrop == true && isPickUp == false)
        {
            floatingEffect += 0.03f;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.005f * Mathf.Sin(floatingEffect) * 0.2f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerController")
        {
            isDrop = false;
            if(PlayerManager.Instance.currentHp < 6)
            {
                Debug.Log("This is Called");
                PlayerManager.Instance.currentHp ++;

                AudioManager.Instance.Play("Soul_pickup");
                //pickUpSound.Play();

                Destroy(gameObject);
            }else if (PlayerManager.Instance.currentHp == 6)
            {
                Destroy(gameObject);
            }

           
            
        }
    }

    IEnumerator Timelife()
    {
        yield return new WaitForSeconds(lifeTime);
        lifeCoinAnim.enabled = true;
        yield return new WaitForSeconds(warningTime);
        gameObject.SetActive(false);
    }
}
