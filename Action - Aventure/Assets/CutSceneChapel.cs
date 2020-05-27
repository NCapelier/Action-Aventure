using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using GameManagement;
using Player;


public class CutSceneChapel : MonoBehaviour
{
    private PlayableDirector timeline;

    private BoxCollider2D boxCol;

    private bool startTimeline;
    private float timeTimeline;

    private bool finished;

    // Start is called before the first frame update
    void Start()
    {
        
        finished = false;
        boxCol = GetComponent<BoxCollider2D>();
        timeline = GetComponent<PlayableDirector>();
    }

    IEnumerator CutScene()
    {
        timeline.Play();
        yield return null;
    }
}
