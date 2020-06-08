using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using GameManagement;
using Management;
using UnityEngine.SceneManagement;

public class CutSceneFinale : MonoBehaviour
{
    //Timer CutScene
    private PlayableDirector timeline;
    [SerializeField] private float timerClip = 0f;
    private bool starTimer = false;
    private bool needToUpdate = false;

    [SerializeField] private Dialog.Conversation dial1;

    [SerializeField] private GameObject blackScreen;
    private SpriteRenderer blackSRend;


    //things need to disabled
    private BoxCollider2D boxCol;

    // Start is called before the first frame update
    void Start()
    {


        timeline = GetComponent<PlayableDirector>();
        blackSRend = blackScreen.GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();

        Color c = blackSRend.material.color;
        c.a = 0f;
        blackSRend.material.color = c;
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            StartCoroutine("Dialog");
        }
    }

    IEnumerator FadeIn()
    {
        for (float f = 0.25f; f <= 1.1; f += 0.25f)
        {
            Color c = blackSRend.material.color;
            c.a = f;
            blackSRend.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }


    }

    IEnumerator Dialog()
    {
        timeline.Play();
        GameCanvasManager.Instance.dialog.isCutScene = true;
        GameCanvasManager.Instance.dialog.StartDialog = dial1;
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        GameCanvasManager.Instance.dialog.isCutScene = true;
        StartCoroutine("FadeIn");
        GameManager.Instance.gameState.gameFinished = true;
        yield return new WaitForSeconds(2f);
        GameManager.Instance.gameState.playerDead = true;
        SuperGameManager.Instance.DestroyAllGameObjects();
        SceneManager.LoadScene("0_MainMenu");

    }
}
