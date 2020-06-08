using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Enemy2FixAnim : MonoBehaviour
    {
        public void GetAnimationEvent(string EventMessage)
        {
            if (EventMessage.Equals("isHit"))
            {
                gameObject.GetComponentInParent<Enemy2Fixe>().anim.SetBool("isHit", false);
                gameObject.GetComponentInParent<Enemy2Fixe>().eyeAnim.SetBool("isHit", false);
            }
            else if (EventMessage.Equals("attackEnded"))
            {
                gameObject.GetComponentInParent<Enemy2Fixe>().anim.SetBool("isAttacking", false);
                gameObject.GetComponentInParent<Enemy2Fixe>().eyeAnim.SetBool("isAttacking", false);
            }

        }
    }
}