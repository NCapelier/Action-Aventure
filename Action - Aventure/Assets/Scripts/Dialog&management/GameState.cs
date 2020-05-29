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

    public bool versatileGet = false;

    public bool CutsceneFlash = false;

    //Forest 2
    public bool cutSForet2 = false;
    //True when enigme 4 flambeaux good
    public bool enigmeForest = false;


    //Chapelle State
    public bool chapelleTrigger = false;
    public bool ChapelleCutSceneFinish = false;

    //When this is True : The playre enter in the dungeon
    public bool isDungeon = false;

    //When false don't show the sign of localisation
    public bool needToShow = true;

    private void Update()
    {
       
    }
}
