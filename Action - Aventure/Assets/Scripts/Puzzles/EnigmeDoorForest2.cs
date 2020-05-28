using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EnigmeDoorForest2 : MonoBehaviour
{
    [SerializeField] private GameObject flambeau1;
    [SerializeField] private GameObject flambeau2;
    [SerializeField] private GameObject flambeau3;
    [SerializeField] private GameObject flambeau4;

    [SerializeField] private Light2D flame1;
    [SerializeField] private Light2D flame2;
    [SerializeField] private Light2D flame3;
    [SerializeField] private Light2D flame4;

    private Color color;

    private bool firstTrue;
    private bool secondTrue;
    private bool thirdTrue;
    private bool fourthTrue;

    private bool needToCheckFirst;
    private bool needToCheckSecond;
    private bool needToCheckThird;
    private bool needToCheckFourth;

    private bool stillGood;

    public static bool isFinish;

    // Start is called before the first frame update
    void Start()
    {
        firstTrue = false;
        secondTrue = false;
        thirdTrue = false;
        fourthTrue = false;

        needToCheckFirst = true;
        needToCheckSecond = false;
        needToCheckThird = false;
        needToCheckFourth = false;

        stillGood = true;
        isFinish = false;

        color = flame1.GetComponent<Light2D>().color;
    }

    // Update is called once per frame
    void Update()
    {
        //TimeOut();

        if (isFinish==true)
        {
            Debug.Log("Win");
            flambeau1.GetComponent<TorchTTK>().isLit = true;
            flambeau2.GetComponent<TorchTTK>().isLit = true;
            flambeau3.GetComponent<TorchTTK>().isLit = true;
            flambeau4.GetComponent<TorchTTK>().isLit = true;
           
        }

        //A déclencher quand le joueur fait une erreru
        if(stillGood == false)
        {
            StartCoroutine("Remover");

        }

        

        if((flambeau1.GetComponent<TorchTTK>().isLit == true || flambeau2.GetComponent<TorchTTK>().isLit == true || flambeau3.GetComponent<TorchTTK>().isLit == true || flambeau4.GetComponent<TorchTTK>().isLit == true) && needToCheckFirst == true && stillGood == true)
        {
            
            Checker1();
            Debug.Log("Checker1");
        }
        if ((flambeau2.GetComponent<TorchTTK>().isLit == true || flambeau3.GetComponent<TorchTTK>().isLit == true || flambeau4.GetComponent<TorchTTK>().isLit == true) && needToCheckSecond == true && stillGood == true && flambeau1.GetComponent<TorchTTK>().isLit == true)
        {
            Checker2();
            Debug.Log("Checker2");
        }
        if ((flambeau3.GetComponent<TorchTTK>().isLit == true || flambeau4.GetComponent<TorchTTK>().isLit == true) && needToCheckThird == true && stillGood == true)
        {
            Checker3();
            Debug.Log("Checker3");
        }
        if (flambeau4.GetComponent<TorchTTK>().isLit == true && needToCheckFourth == true && stillGood == true)
        {
            Checker4();
            Debug.Log("Checker4");
        }
    }

    //A déclencher dès qu'un flambeau est en islit pour checker si c'est le bon
    void Checker1()
    {
        if(flambeau1.GetComponent<TorchTTK>().isLit == true)
        {
            stillGood = true;
            firstTrue = true;
            needToCheckFirst = false;
            needToCheckSecond = true;
        }else 
        {
            stillGood = false;

        }

        
    }
    void Checker2()
    {
        
        if (flambeau2.GetComponent<TorchTTK>().isLit == true && flambeau1.GetComponent<TorchTTK>().isLit == true)
        {
            stillGood = true;
            secondTrue = true;
            needToCheckSecond = false;
            needToCheckThird = true;
        }
        else
        {
            stillGood = false;

        }


    }
    void Checker3()
    {
        
        if (flambeau3.GetComponent<TorchTTK>().isLit == true && flambeau2.GetComponent<TorchTTK>().isLit == true && flambeau1.GetComponent<TorchTTK>().isLit == true)
        {
            stillGood = true;
            thirdTrue = true;
            needToCheckThird = false;
            needToCheckFourth = true;
        }
        else
        {
            stillGood = false;

        }


    }

    void Checker4()
    {

        if (flambeau3.GetComponent<TorchTTK>().isLit == true && flambeau2.GetComponent<TorchTTK>().isLit == true && flambeau1.GetComponent<TorchTTK>().isLit == true && flambeau4.GetComponent<TorchTTK>().isLit == true)
        {
            stillGood = true;
            fourthTrue = true;
            needToCheckFourth = false;
            isFinish = true;
        }
        else
        {
            stillGood = false;

        }


    }

    void TimeOut()
    {
        if(stillGood == true && flambeau3.GetComponent<TorchTTK>().isLit == false && (needToCheckSecond == true || needToCheckThird == true || needToCheckFourth == true))
        {
            stillGood = false;
        }
    }

    IEnumerator Remover()
    {
        
        yield return new WaitForSeconds(1f);
        flame1.GetComponent<Light2D>().color = Color.red;
        flame2.GetComponent<Light2D>().color = Color.red;
        flame3.GetComponent<Light2D>().color = Color.red;
        flame4.GetComponent<Light2D>().color = Color.red;

        yield return new WaitForSeconds(1f);
        flambeau1.GetComponent<TorchTTK>().isLit = false;
        flambeau2.GetComponent<TorchTTK>().isLit = false;
        flambeau3.GetComponent<TorchTTK>().isLit = false;
        flambeau4.GetComponent<TorchTTK>().isLit = false;
        yield return new WaitForSeconds(0.1f);
        flame1.GetComponent<Light2D>().color = color;
        flame2.GetComponent<Light2D>().color = color;
        flame3.GetComponent<Light2D>().color = color;
        flame4.GetComponent<Light2D>().color = color;

        stillGood = true;
        needToCheckFirst = true;
        needToCheckSecond = false;
        needToCheckThird = false;
        needToCheckFourth = false;

        firstTrue = false;
        secondTrue = false;
        thirdTrue = false;
        fourthTrue = false;
    }
}
