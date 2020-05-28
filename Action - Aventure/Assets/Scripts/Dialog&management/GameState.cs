using UnityEngine;

public class GameState : MonoBehaviour
{
     public bool lanternGet = false;
    //When this is True : Give the possibility to attack and use the light.

    public bool cutSceneBucheronFinish = false;
    
     public bool potionGet = false;
    //When this is True : Give the possibility to regain life.

    //Check First Visit to Village
    //First dialog Croque Mort done.
     public bool firstDialogCM = false;
    //First dialog Frère Chasseur done.
    public bool firstDialogFC = false;

    //dialog of Maison brullée done
    public bool triggerMB = false;

    //cutscene Cave done
    public bool cutSCaveDone = false;

    //When this is True : The player can use the versatile ability.
    public bool versatileGet = false;

    public bool chapelleTrigger = false;
    public bool ChapelleCutSceneFinish = false;

    //When this is True : The playre enter ine the dungeon
    public bool isDungeon = false;

    public bool needToShow = true;

    private void Update()
    {
       
    }
}
