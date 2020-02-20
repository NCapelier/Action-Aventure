using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchInOrder : Torch
{
    [SerializeField]
    private GameObject prev;
    private Torch prevTorch;
    [SerializeField]
    private bool killsPrev;
    [SerializeField]
    private float timeToKill;

    protected override void Start()
    {
        base.Start();
        prevTorch = prev.GetComponent<Torch>();
        /*
        if (killsPrev)
        {
            StartCoroutine(KillPrevious());
        }
        */
    }

    private void Update()
    {
        if (killsPrev)
        {
            StartCoroutine(KillPrevious());
        }
    }
    /// <summary>
    /// Light flame if a specific one is already lit
    /// </summary>
    protected override void Light()
    {
        if (prevTorch.isLit)
        {
            base.Light();
        }
    }

    IEnumerator KillPrevious()
    {
        if (prevTorch.isLit)
        {
            killsPrev = false;
            yield return new WaitForSeconds(timeToKill);
            if (!isLit)
            {
                prevTorch.PutOut();
            }
            killsPrev = true;
        }

        //StartCoroutine(KillPrevious());
    }
}
