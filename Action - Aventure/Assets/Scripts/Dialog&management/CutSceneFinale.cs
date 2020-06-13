using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using GameManagement;
using Management;
using UnityEngine.SceneManagement;
using GameSound;

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

    [SerializeField] private GameObject title;
    private SpriteRenderer titleRend;


    [SerializeField] private GameObject illuVictoire;

    [SerializeField] private GameObject illu1Credits;
    [SerializeField] private GameObject illu2Credits;

    [SerializeField] private GameObject blackS2;
    [SerializeField] private GameObject blackS3;
    [SerializeField] private GameObject blackS4;
    [SerializeField] private GameObject blackS5;



    [SerializeField] private GameObject musiques;

    //things need to disabled
    private BoxCollider2D boxCol;

    // Start is called before the first frame update
    void Start()
    {

        timeline = GetComponent<PlayableDirector>();
        blackSRend = blackScreen.GetComponent<SpriteRenderer>();
        titleRend = title.GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();

        Color c = blackSRend.material.color;
        c.a = 0f;
        blackSRend.material.color = c;

        Color d = titleRend.material.color;
        d.a = 0f;
        titleRend.material.color = c;

        Color e = illuVictoire.GetComponent<SpriteRenderer>().material.color;
        e.a = 0f;
        illuVictoire.GetComponent<SpriteRenderer>().material.color = e;

        Color f = illu1Credits.GetComponent<SpriteRenderer>().material.color;
        f.a = 0f;
        illu1Credits.GetComponent<SpriteRenderer>().material.color = f;

        Color g = illu2Credits.GetComponent<SpriteRenderer>().material.color;
        g.a = 0f;
        illu2Credits.GetComponent<SpriteRenderer>().material.color = g;

        Color h = blackS2.GetComponent<SpriteRenderer>().material.color;
        h.a = 0f;
        blackS2.GetComponent<SpriteRenderer>().material.color = h;

        Color i = blackS3.GetComponent<SpriteRenderer>().material.color;
        i.a = 0f;
        blackS3.GetComponent<SpriteRenderer>().material.color = i;

        Color j = blackS4.GetComponent<SpriteRenderer>().material.color;
        j.a = 0f;
        blackS4.GetComponent<SpriteRenderer>().material.color = j;

        Color k = musiques.GetComponent<SpriteRenderer>().material.color;
        k.a = 0f;
        musiques.GetComponent<SpriteRenderer>().material.color = k;

        Color l = blackS5.GetComponent<SpriteRenderer>().material.color;
        l.a = 0f;
        blackS5.GetComponent<SpriteRenderer>().material.color = l;



    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            StartCoroutine("Dialog");
        }
    }

    IEnumerator BlackScreenFade()
    {
        for (float f = 0.1f; f <= 1.1; f += 0.10f)
        {
            Color c = blackSRend.material.color;
            c.a = f;
            blackSRend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

    }
    IEnumerator BlackScreenFade2()
    {
        for (float f = 0.1f; f <= 1.1; f += 0.10f)
        {
            Color c = blackS2.GetComponent<SpriteRenderer>().material.color;
            c.a = f;
            blackS2.GetComponent<SpriteRenderer>().material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

    }
    IEnumerator BlackScreenFade3()
    {
        for (float f = 0.1f; f <= 1.1; f += 0.070f)
        {
            Color c = blackS3.GetComponent<SpriteRenderer>().material.color;
            c.a = f;
            blackS3.GetComponent<SpriteRenderer>().material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

    }

    IEnumerator BlackScreenFade4()
    {
        for (float f = 0.1f; f <= 1.1; f += 0.070f)
        {
            Color c = blackS4.GetComponent<SpriteRenderer>().material.color;
            c.a = f;
            blackS4.GetComponent<SpriteRenderer>().material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

    }
    IEnumerator BlackScreenFade5()
    {
        for (float f = 0.1f; f <= 1.1; f += 0.070f)
        {
            Color c = blackS5.GetComponent<SpriteRenderer>().material.color;
            c.a = f;
            blackS5.GetComponent<SpriteRenderer>().material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

    }
    IEnumerator TitleFade()
    {
        for (float f = 0.1f; f <= 1.1; f += 0.10f)
        {
            Color c = titleRend.material.color;
            c.a = f;
            titleRend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }


    }

    IEnumerator FadeInVictoire()
    {
        for (float f = 0.1f; f <= 1.1; f += 0.10f)
        {
            Color e = illuVictoire.GetComponent<SpriteRenderer>().material.color;
            e.a = f;
            illuVictoire.GetComponent<SpriteRenderer>().material.color = e;
            yield return new WaitForSeconds(0.05f);
        }


    }
    IEnumerator FadeInMusique()
    {
        for (float f = 0.1f; f <= 1.1; f += 0.10f)
        {
            Color e = musiques.GetComponent<SpriteRenderer>().material.color;
            e.a = f;
            musiques.GetComponent<SpriteRenderer>().material.color = e;
            yield return new WaitForSeconds(0.05f);
        }


    }

    IEnumerator Credits1()
    {
        for (float f = 0.1f; f <= 1.1; f += 0.070f)
        {
            Color e = illu1Credits.GetComponent<SpriteRenderer>().material.color;
            e.a = f;
            illu1Credits.GetComponent<SpriteRenderer>().material.color = e;
            yield return new WaitForSeconds(0.05f);
        }


    }
    IEnumerator Credits2()
    {
        for (float f = 0.1f; f <= 1.1; f += 0.070f)
        {
            Color e = illu2Credits.GetComponent<SpriteRenderer>().material.color;
            e.a = f;
            illu2Credits.GetComponent<SpriteRenderer>().material.color = e;
            yield return new WaitForSeconds(0.05f);
        }


    }

    IEnumerator Dialog()
    {
        timeline.Play();
        GameCanvasManager.Instance.dialog.isCutScene = true;
        GameCanvasManager.Instance.dialog.StartDialog = dial1;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(2.7f);
        //AudioManager.Instance.PlayMusic(MusicID.Ending);
        yield return new WaitForSeconds(0.8f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        yield return new WaitForSeconds(3f);
        GameCanvasManager.Instance.dialog.forceUpdate = true;
        GameCanvasManager.Instance.dialog.isCutScene = true;
        StartCoroutine("FadeInVictoire");
        GameManager.Instance.gameState.gameFinished = true;
        yield return new WaitForSeconds(5f);
        StartCoroutine("BlackScreenFade");
        yield return new WaitForSeconds(1f);
        StartCoroutine("BlackScreenFade2");
        yield return new WaitForSeconds(1f);
        StartCoroutine("TitleFade");
        yield return new WaitForSeconds(1f);
        StartCoroutine("Credits1");
        yield return new WaitForSeconds(9.3f);
        StartCoroutine("BlackScreenFade3");
        yield return new WaitForSeconds(2f);
        StartCoroutine("Credits2");
        yield return new WaitForSeconds(8f);
        StartCoroutine("BlackScreenFade4");
        yield return new WaitForSeconds(2f);
        StartCoroutine("FadeInMusique");
        yield return new WaitForSeconds(8f);
        StartCoroutine("BlackScreenFade5");
        yield return new WaitForSeconds(8.8f);
        SuperGameManager.Instance.DestroyAllGameObjects();
        SceneManager.LoadScene("0_MainMenu");

    }

}
