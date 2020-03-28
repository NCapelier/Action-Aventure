using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Enemy1Manager : EnemyParent
    {
        
        
        
        void Awake()
        {
            
        }
        
        void Start()
        {
            hp = maxHp;
        }
        
        void Update()
        {
            Debug.Log(hp);
        }



    }
}