using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{

    public bool playerDead = false;

    public bool videoIntroDone = false;

    public bool inPause = false;

    //PARTIE TUTO

     public bool lanternGet = false;
    //When this is True : Give the possibility to attack and use the light.

    public bool cutSceneBucheronFinish = false;
    
     public bool potionGet = false;
    //When this is True : Give the possibility to regain life.

    //PARTIE FOREST 
    public bool firstTreasureDone = false;
    public bool secondTreasureDone = false;

    //PARTIE VILLAGE
    //First dialog Croque Mort done.
    public bool firstDialogCM = false;
    //First dialog Frère Chasseur done.
    public bool firstDialogFC = false;
    //dialog of Maison brullée done
    public bool triggerMB = false;
    //cutscene Cave done
    public bool cutSCaveDone = false;
    public bool enemyDone = false;

    public bool versatileGet = false;

    public bool CutsceneFlash = false;


    //FOREST2
    public bool cutSForet2 = false;
    //True when enigme 4 flambeaux good
    public bool enigmeForest = false;

    public bool thirdTreasureDone = false;
    public bool fourthTreasureDone = false;


    //CHAPPELLE
    public bool chapelleTrigger = false;
    public bool ChapelleCutSceneFinish = false;
    public bool monstre1chapelle = false;
    public bool monstre2chapelle = false;
    public bool monstre3chapelle = false;

    //ENTREE DONJON
    //When this is True : The playre enter in the dungeon
    public bool isDungeon = false;

    //When false don't show the sign of localisation
    public bool needToShow = true;

    public bool gameFinished = false;
}
