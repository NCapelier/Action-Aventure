using UnityEngine;
using GameManagement;

namespace Dialog
{
    public class DialogTrigger : MonoBehaviour
    {
       

        public Conversation dialog = null;

        void Start()
        {
            GameCanvasManager.Instance.dialog.StartDialog = dialog;
        }
    }
}