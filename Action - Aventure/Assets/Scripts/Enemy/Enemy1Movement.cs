using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    /*
    //XP The enemy moves according positions selected by Us.

    //Start Statement

    public float speed = 10f;
    [SerializeField]

    private Transform target;

    private int waypointsIndex = 0;

    [SerializeField]
    private bool lightFound = false;

    //End Statement


    void Start()
    {
        target = GetWaypoints.points[0];    
    }

    // Update is called once per frame
    void Update()
    {
        //When the enemu don't found light, he keeps following points.
        if(lightFound == false)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime);

            //Check if the position is approximatively the good one
            if (Vector2.Distance(transform.position, target.position) <= 0.05)
            {
                //go to next waypoints
                GetNextWaypoint();
            }

            if (waypointsIndex >= GetWaypoints.points.Length - 1)
            {
                target = GetWaypoints.points[0];
                waypointsIndex = 0;
            }
        }

       

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (lightFound == false)
            {
                lightFound = true;

            }
            else {
                lightFound = false;
            }

           
        }
        
    }
    private void GetNextWaypoint()
    {  
        waypointsIndex++;
        //fix the new waypoints positions (= new target)
        target = GetWaypoints.points[waypointsIndex];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       
        Debug.Log(lightFound);
        target = collision.transform;
        Vector3 dir = target.position - transform.position;


            if (Vector2.Distance(transform.position, target.position) <= 0.2)
        {
            collision.gameObject.SetActive(false);
            lightFound = false;
        }
    }
    */
}
