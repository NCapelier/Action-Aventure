using UnityEngine;
using GameManagement;

public class updateCutSChapelleDone : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameState.ChapelleCutSceneFinish == true)
        {
            gameObject.SetActive(false);
        }
    }
}
