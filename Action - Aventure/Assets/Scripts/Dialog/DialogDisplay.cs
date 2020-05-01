using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dialog
{
    /// <summary>
    /// NCO - Dialog management
    /// </summary>
    public class DialogDisplay : MonoBehaviour
    {

        #region Variables

        [SerializeField] DialogOverlay overlay = null;
        [SerializeField] DialogText textDisplay = null;
        [SerializeField] DialogPortrait portrait = null;

        Conversation conversation = null;
        int lineIndex = 0;
        [HideInInspector] public bool runningConversation = false;

        #endregion

        #region properties
        /// <summary>
        /// Used to start a new conversation
        /// </summary>
        public Conversation StartDialog
        {
            get
            {
                return conversation;
            }
            set
            {
                conversation = value;
                StartConversation();
            }
        }

        #endregion

        /// <summary>
        /// called when a new conversation is started
        /// </summary>
        void StartConversation()
        {
            overlay.gameObject.SetActive(true);
            textDisplay.gameObject.SetActive(true);
            portrait.gameObject.SetActive(true);

            textDisplay.leftSpeakerName.text = conversation.leftSpeaker.fullName;
            textDisplay.rightSpeakerName.text = conversation.rightSpeaker.fullName;

            textDisplay.textLine.text = conversation.lines[lineIndex].text;

            portrait.leftPortrait.sprite = conversation.leftSpeaker.portrait[conversation.lines[lineIndex].leftPortraitIndex];
            portrait.rightPortrait.sprite = conversation.rightSpeaker.portrait[conversation.lines[lineIndex].rightPortraitIndex];

            runningConversation = true;
            
        }

        /// <summary>
        /// Updates a running conversation when pressing A_Button
        /// </summary>
        void UpdateConversation()
        {
            if(lineIndex < conversation.lines.Length - 1)
            {
                lineIndex++;

                textDisplay.textLine.text = conversation.lines[lineIndex].text;

                portrait.leftPortrait.sprite = conversation.leftSpeaker.portrait[conversation.lines[lineIndex].leftPortraitIndex];
                portrait.rightPortrait.sprite = conversation.rightSpeaker.portrait[conversation.lines[lineIndex].rightPortraitIndex];
            }
            else
            {
                //--> deactivate canvas
                overlay.gameObject.SetActive(false);
                textDisplay.gameObject.SetActive(false);
                portrait.gameObject.SetActive(false);

                runningConversation = false;
                lineIndex = 0;
                conversation = null;
            }
        }
        
        void Update()
        {
            if(Input.GetButtonDown("A_Button") && runningConversation)
            {
                UpdateConversation();
            }
        }
        
        
        
    }
}