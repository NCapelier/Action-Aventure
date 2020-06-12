using UnityEngine;
using Lantern;

namespace GameManagement
{
    public class SceneTransition : MonoBehaviour
    {
        public int zoneIndexGiver;
        [SerializeField] string nextScene = "";
        [SerializeField] Vector2 nextSceneEntryPoint = Vector2.zero;

        //[HideInInspector] public bool isActive = true;

        private void OnTriggerEnter2D(Collider2D collision)
        {
           
            /*if (!isActive)
                return;*/
            if(collision.tag == "PlayerController")
            {
                Debug.Log("trigger");
                SceneLoader.GoToScene(nextScene, nextSceneEntryPoint);
                ZoneScripter.isTrigger = true;
                ZoneIntroduction.zoneIndex = zoneIndexGiver;

            }
        }

    }
}