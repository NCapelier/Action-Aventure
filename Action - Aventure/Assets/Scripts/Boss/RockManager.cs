using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Management;

namespace Boss
{
    /// <summary>
    /// NCO
    /// </summary>
    public enum rockState { Idle, Shadow, Rock};

    public class RockManager : Singleton<RockManager>
    {
        #region Variables
        public RockBehaviour[] rockStands;
        #endregion

        public void SpawnShadow()
        {
            List<RockBehaviour> idleRockStands = new List<RockBehaviour>();
            for(int i = 0; i < rockStands.Length; i++)
            {
                if(rockStands[i].currentRockState == rockState.Idle)
                {
                    idleRockStands.Add(rockStands[i]);
                }
            }
            int ran = Random.Range(0, idleRockStands.Count);
            idleRockStands[ran].currentRockState = rockState.Shadow;
        }

        public void SpawnRocks()
        {
            for(int i = 0; i < rockStands.Length; i++)
            {
                if(rockStands[i].currentRockState == rockState.Shadow)
                {
                    rockStands[i].currentRockState = rockState.Rock;
                }
            }
        }

        public void DestroyRocks()
        {
            for (int i = 0; i < rockStands.Length; i++)
            {
                rockStands[i].currentRockState = rockState.Idle;
            }
        }
    }
}