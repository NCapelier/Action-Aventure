using UnityEngine;

public class XP_GameManager : MonoBehaviour
{

    public GameObject lightObject;
    // Start is called before the first frame update
    public bool trigerDone = false;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            lightObject.SetActive(true);
        }
        
    }
}
