using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    /// <summary>
    /// NCO - Parent class of every enemy object
    /// </summary>
    public abstract class EnemyParent : MonoBehaviour
    {
        [HideInInspector] public int hp;
        [Range(1, 50)]
        [SerializeField] int maxHp = 10;

        public int TakeDamages
        {
            set
            {
                hp -= value;
            }
        }

        public int Heal
        {
            set
            {
                hp += value;
            }
        }

        void Update()
        {

        }

        void UpdateHp()
        {
            if (hp > maxHp)
            {
                hp = maxHp;
            }
            if (hp <= 0)
            {
                Death();
            }
        }

        void Death()
        {
            //death
        }

    }
}