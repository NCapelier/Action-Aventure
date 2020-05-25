using UnityEngine;
using Management;

namespace GameManagement
{
    /// <summary>
    /// NCO - General management of the game.
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {

        #region Variables

        [HideInInspector] public GameState gameState = null;

        #endregion

        void Awake()
        {
            MakeSingleton(true);
        }

        void Start()
        {
            gameState = GetComponent<GameState>();
        }
    }
}