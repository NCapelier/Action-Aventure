using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeDoorForest2 : MonoBehaviour
{
    [SerializeField] private GameObject flambeau1;
    [SerializeField] private GameObject flambeau2;
    [SerializeField] private GameObject flambeau3;
    [SerializeField] private GameObject flambeau4;

    private bool firstTrue;
    private bool secondTrue;
    private bool thirdTrue;
    private bool fourthTrue;

    private bool needToCheckFirst;
    private bool needToCheckSecond;
    private bool needToCheckThird;
    private bool needToCheckFourth;

    private bool stillGood;

    private bool isFinish;

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
        Debug.Log("Wrong");
        yield return new WaitForSeconds(1f);
        //Mettre Feedback erreurs.


        flambeau1.GetComponent<TorchTTK>().isLit = false;
        flambeau2.GetComponent<TorchTTK>().isLit = false;
        flambeau3.GetComponent<TorchTTK>().isLit = false;
        flambeau4.GetComponent<TorchTTK>().isLit = false;

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
