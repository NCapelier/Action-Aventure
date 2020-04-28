using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    /// <summary>
    /// Script of Coin's behaviour (floating + updating UI)
    /// </summary>
    
    private bool isDrop;
    private bool isPickUp;
    private float floatingEffect = 0f;
    [Header("Variables")]
    [Range(0.1f, 10f)]
    public float lifeTime;
    public float warningTime;

    private Animator coinAnim;

    // Start is called before the first frame update
    void Start()
    {
        isDrop = true;
        isPickUp = false;
        StartCoroutine("Timelife");
        coinAnim = GetComponent<Animator>();
        coinAnim.enabled = false;
    } 

    // Update is called once per frame
    void Update()
    {
        if(isDrop == true && isPickUp == false)
        {
            floatingEffect += 0.03f;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.005f * Mathf.Sin(floatingEffect) * 0.2f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerController")
        {
            isDrop = false;
            GoldTextScript.coinAmount += 1;
            Destroy(gameObject);

        }
    }

    IEnumerator Timelife()
    {
        Debug.Log("called");
        yield return new WaitForSeconds(lifeTime);
        coinAnim.enabled = true;
        yield return new WaitForSeconds(warningTime);
        Destroy(gameObject);
    }
}
