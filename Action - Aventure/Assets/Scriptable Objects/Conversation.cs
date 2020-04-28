using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dialog
{
    [System.Serializable] public struct Line
    {
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