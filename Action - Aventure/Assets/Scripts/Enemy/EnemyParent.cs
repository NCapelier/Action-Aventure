using UnityEngine;
using GameSound;

namespace Enemy
{
    /// <summary>
    /// NCO - Parent class of every enemy object
    /// </summary>
    public abstract class EnemyParent : MonoBehaviour
    {
        #region Variables

        // health points
        [HideInInspector] public int hp;

        // editor variables : health points and armor variables
        [Range(1, 50)]
        public int maxHp = 10;

        //Sound
        Sound deathClip;
        AudioSource deathSound;

        #endregion

        #region Properties

        /// <summary>
        /// used to deal damages to the entity
        /// </summary>
        public int TakeDamages
        {
            set
            {
                hp -= value;
                UpdateHp();
            }
        }

        /// <summary>
        /// used to give health points to the entity
        /// </summary>
        public int Heal
        {
            set
            {
                hp += value;
            }
        }

        #endregion

        protected virtual void EnemyStart()
        {
            hp = maxHp;

            //Sound
            //deathClip = AudioManager.Instance.sounds_notUniqueObject["Enemy_death1"];
            //AudioManager.Instance.MakeAudioSource(deathClip, gameObject);
            //deathSound = GetComponent<AudioSource>();
        }
         
        /// <summary>
        /// Avoids the hp to exceed the hp cap and lauched the Death() method if hp < 0
        /// </summary>
        public virtual void UpdateHp()
        {
            if (hp > maxHp)
            {
                hp = maxHp;
            }
            if (hp <= 0)
            {
                Instantiate(Resources.Load("Prefabs/Enemy/Coin"), transform.position, Quaternion.identity);
                Death();
            }
        }

        /// <summary>
        /// override this method to kill the entity
        /// </summary>
        public virtual void Death()
        {
            AudioManager.Instance.Play("Enemy_death1");
            //deathSound.Play();

            Destroy(gameObject);
        }

    }
}