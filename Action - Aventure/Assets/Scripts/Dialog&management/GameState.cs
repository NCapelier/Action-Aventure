using UnityEngine;

public class GameState : MonoBehaviour
{
     public bool lanternGet = false;
    //When this is True : Give the possibility to attack and use the light.

    
     public bool potionGet = false;
    //When this is True : Give the possibility to regain life.

    //Check First Visit to Village
    //First dialog Croque Mort done.
     public bool firstDialogCM = false;
    //First dialog Frère Chasseur done.
    public bool firstDialogFC = false;

    //When this is True : The player can use the versatile ability.
    public bool versatileGet = false;

    //When this is True : The playre enter ine the dungeon
    public bool isDungeon = false;

    public bool needToShow = true;

    private void Update()
    {
       
    }
}
