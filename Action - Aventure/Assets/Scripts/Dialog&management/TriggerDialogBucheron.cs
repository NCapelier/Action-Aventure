using UnityEngine;
using Player;
using GameManagement;
using UnityEngine.Playables;



public class TriggerDialogBucheron : MonoBehaviour
{

    /// <summary>
    /// XP - Ce script gère la cut scène du bucheron.
    /// </summary>
    //references Ennemi
    public GameObject enemy;
    public GameObject enemyToKill;
   

    public GameObject pnjTokill;


    private BoxCollider2D bxCollider;
    private bool playerHere;

    //Cutscene Ref
    [SerializeField] private Dialog.Conversation dialHelp1;
 
    [SerializeField] private Dialog.Conversation dialHelp3;
    private bool dialog1Finished;
    private PlayableDirector timeline;
    private float timerClip = 0f;
    private bool starTimer = false;


    public GameObject flambeau;

 
    // Start is called before the first frame update
    void Start()
    {
        
        bxCollider = GetComponent<BoxCollider2D>();
        flambeau.GetComponent<TorchTTK>().isLit = true;

        timeline = GetComponent<PlayableDirector>();

        timeline.Stop();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Quand le player rentre dans la zone de collision, la cut scene se lance. Le joueur doit passer le dialogue pour continuer.
        if (collision.gameObject.tag == "PlayerController")
        {
            playerHere = true;

            bxCollider.enabled = false;

            PlayerManager.Instance.controller.isDialoging = true;

            GameCanvasManager.Instance.dialog.StartDialog = dialHelp1;

        }


    }

    private void Update()
    {
        //A la fin de la conversation, l'anim de la timeline se lance pour ensuite lancer le deuxième dialogue.
        if (GameCanvasManager.Instance.dialog.runningConversation == false && playerHere == true)
        {
            PlayerManager.Instance.controller.isDialoging = true;

            timeline.Play();

            starTimer = true;
  
        }


        if (timerClip >= 1300 && starTimer == true)
        {
            starTimer = false;

            GameCanvasManager.Instance.dialog.StartDialog = dialHelp3;

            //jouer coup de feu;

            timeline.Stop();

            flambeau.GetComponent<TorchTTK>().isLit = false;

            pnjTokill.SetActive(false);


            Instantiate(enemy, enemyToKill.transform.position, Quaternion.identity);

            Destroy(enemyToKill);

            Destroy(gameObject);
        }

        //au début de l'animation, lancer un chrono pour l'arreter au bon moment.
        if (starTimer == true)
        {
            timerClip += 1;
        }
    }

}
