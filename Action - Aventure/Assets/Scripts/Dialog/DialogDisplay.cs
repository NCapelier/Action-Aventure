using UnityEngine;
using Player;

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

        Color speakerColor = new Color(1f, 1f, 1f, 1f);
        Color listenerColor = new Color(0.5f, 0.5f, 0.5f, 1f);

        //cut scene dialogs
        [HideInInspector] public bool isCutScene = false;
        [HideInInspector] public bool forceUpdate = false;

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
            PlayerManager.Instance.controller.isDialoging = true;

            overlay.gameObject.SetActive(true);
            textDisplay.gameObject.SetActive(true);
            portrait.gameObject.SetActive(true);

            textDisplay.leftSpeakerName.text = conversation.leftSpeaker.fullName;
            textDisplay.rightSpeakerName.text = conversation.rightSpeaker.fullName;

            

            textDisplay.textLine.text = conversation.lines[lineIndex].text;

            portrait.leftPortrait.sprite = conversation.leftSpeaker.portrait[conversation.lines[lineIndex].leftPortraitIndex];
            portrait.rightPortrait.sprite = conversation.rightSpeaker.portrait[conversation.lines[lineIndex].rightPortraitIndex];

            if (conversation.lines[lineIndex].speaker == Speaker.Left)
            {
                portrait.rightPortrait.color = listenerColor;
                portrait.leftPortrait.color = speakerColor;
            }
            else
            {
                portrait.leftPortrait.color = listenerColor;
                portrait.rightPortrait.color = speakerColor;
            }

            if (conversation.leftSpeaker.fullName == null)
            {
                overlay.GetComponent<DialogOverlay>().leftSpeakerOverlay.SetActive(false);
            }
            if (conversation.rightSpeaker.fullName == null)
            {
                overlay.GetComponent<DialogOverlay>().rightSpeakerOverlay.SetActive(false);
            }

            runningConversation = true;

        }

        /// <summary>
        /// Updates a running conversation when pressing A_Button
        /// </summary>
        void UpdateConversation()
        {
            if (lineIndex < conversation.lines.Length - 1)
            {
                lineIndex++;

                textDisplay.textLine.text = conversation.lines[lineIndex].text;

                if (conversation.lines[lineIndex].speaker == Speaker.Left)
                {
                    portrait.rightPortrait.color = listenerColor;
                    portrait.leftPortrait.color = speakerColor;
                }
                else
                {
                    portrait.leftPortrait.color = listenerColor;
                    portrait.rightPortrait.color = speakerColor;
                }

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
                isCutScene = false;
                PlayerManager.Instance.controller.isDialoging = false;
            }
        }

        void Update()
        {
            if ((Input.GetButtonDown("A_Button") && runningConversation && !isCutScene)
                || (isCutScene && forceUpdate))
            {
                forceUpdate = false;
                UpdateConversation();
            }
        }



    }
}