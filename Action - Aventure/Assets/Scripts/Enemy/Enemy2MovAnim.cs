using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Enemy2MovAnim : MonoBehaviour
    {
        public void GetAnimationEvent(string EventMessage)
        {
            if (EventMessage.Equals("isHit"))
            {
                gameObject.GetComponentInParent<Enemy2Movement>().anim.SetBool("isHit", false);
                gameObject.GetComponentInParent<Enemy2Movement>().eyeAnim.SetBool("isHit", false);
            }
            else if (EventMessage.Equals("attackEnded"))
            {
                gameObject.GetComponentInParent<Enemy2Movement>().anim.SetBool("isAttacking", false);
                gameObject.GetComponentInParent<Enemy2Movement>().eyeAnim.SetBool("isAttacking", false);
            }

        }
    }
}