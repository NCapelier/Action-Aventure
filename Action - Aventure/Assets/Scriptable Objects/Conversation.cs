using UnityEngine;

namespace Dialog
{

    public enum Speaker {Left, Right};

    [System.Serializable] public struct Line
    {
        public Speaker speaker;
        public int leftPortraitIndex, rightPortraitIndex;

        [TextArea(2, 5)] public string text;
    }

   [CreateAssetMenu(fileName = "New Conversation", menuName = "Dialog/Conversation")]
    public class Conversation : ScriptableObject
    {

        public Character leftSpeaker, rightSpeaker;
        public Line[] lines;
        
    }
}