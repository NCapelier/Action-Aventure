using UnityEngine;

namespace Dialog
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Dialog/Character")]
    public class Character : ScriptableObject
    {

        public string fullName;
        public Sprite[] portrait;
        
    }
}