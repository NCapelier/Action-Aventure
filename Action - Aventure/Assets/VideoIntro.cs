using GameManagement;
using UnityEngine;
using Player;
using UnityEngine.Video;

public class VideoIntro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameState.videoIntroDone == false)
        {
            PlayerManager.Instance.controller.isDialoging = true;

            //LANCER LA VIDEO
        }
    }
}
