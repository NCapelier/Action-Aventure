using UnityEngine;

namespace Enemy
{
    public class GetWaypoints : MonoBehaviour
    {
        //Able to stock the target
        public Transform[] points;

        void Awake()
        {
            points = new Transform[transform.childCount];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = transform.GetChild(i);
            }
        }
    }
}
