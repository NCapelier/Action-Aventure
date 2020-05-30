using UnityEngine;
using GameManagement;

namespace Dialog
{
    public class DialogTrigger : MonoBehaviour
    {
       /// <summary>
       /// NCO - ONLY USED FOR DEV SCENES, NOT ACTUAL GAME
       /// </summary>

        public Conversation dialog = null;

        void Start()
        {
            GameCanvasManager.Instance.dialog.StartDialog = dialog;
        }
    }
}