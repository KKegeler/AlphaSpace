using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyMovementScript : MonoBehaviour {

    private Rigidbody2D r2D;

    private bool reachedDestination = true;

    private int campaignAt;
    private int tempAt;
    private Vector3[] path;
    private int currentPosition;

    //wall Boundaries
    float wall_left = -10.0f;
    float wall_right = 15.0f;
    float wall_top = 5.0f;
    float wall_bottom = -5.0f;

    //AI properties
    Vector2 AI_Position;
    public float Speed = 1.0f;
    private int i = 0;
    //Get two Random values within a Range (Screen dimensions)
    float randomX = 0;
    float randomY = 0;

    // Use this for initialization
    void Start () {
        r2D = GetComponent<Rigidbody2D>();

        if (r2D == null)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");
    }

    // Update is called once per frame
    void Update()
    {

        if (GameControl.instance.gameState == GameState.campaign)
        {
            float dist = Vector2.Distance(path[i], transform.position);
            transform.position = Vector2.MoveTowards(transform.position, path[i], Time.deltaTime * Speed);
            if (dist <= 0.1f)
                this.i++;
            if (i >= path.Length)
                gameObject.SetActive(false);
        }

        else
        {
            if (reachedDestination)
            {
                randomX = Random.Range(wall_left, wall_right);
                //Debug.Log("Random X: " + randomX);
                randomY = Random.Range(wall_bottom, wall_top);
                //Debug.Log("Random Y: " + randomY);
                reachedDestination = false;
            }

            AI_Position = transform.position;


            //Create a Vector2 out of the Random values
            Vector2 randomXY = new Vector2(randomX, randomY);

            //Get the Direction from AI to the RandomXY generated
            Vector2 Direction = randomXY - AI_Position;

            //Normalize the Direction to apply appropriatly
            Direction = Direction.normalized;

            //Check that your AI is within your boundaries
            if (AI_Position.x > wall_left && AI_Position.x < wall_right
                && AI_Position.y > wall_bottom && AI_Position.y < wall_top)
            {
                //Make AI move in the Direction (adjust speed to your needs)
                float step = Speed * Time.deltaTime;
                r2D.position = Vector2.MoveTowards(transform.position, randomXY, step);
                if (r2D.position.x - randomX <= 0.1 && r2D.position.y - randomY <= 0.1)
                {
                    reachedDestination = true;
                }
            }
            else
            {
                //make your AI do something when its not within the boundaries
                //maybe generate a new direction?
            }
        }
    }

    public void onReuse()
    {
        if (GameControl.instance.gameState == GameState.campaign)
        {
            GameObject cManager = GameObject.Find("CampaignManager");
            CampaignManager campaignManager = cManager.GetComponent<CampaignManager>();
            i = 0;
            path = null;
            campaignAt = campaignManager.campaignAt;
            tempAt = campaignManager.tempAt;
            if (campaignAt == 0)
            {
                path = new Vector3[6];
                path[0] = new Vector3(4f, 4f);
                path[1] = new Vector3(2f, 2f);
                path[2] = new Vector3(0f, -0.5f);
                path[3] = new Vector3(-2f, -2f);
                path[4] = new Vector3(-4f, -3f);
                path[5] = new Vector3(-5f, -5f);
            }
            else if (campaignAt == 1)
            {
                if (tempAt == 0)
                {
                    path = new Vector3[7];
                    path[0] = new Vector3(8f, 4f);
                    path[1] = new Vector3(6f, 2f);
                    path[2] = new Vector3(4f, 4f);
                    path[3] = new Vector3(2f, 2f);
                    path[4] = new Vector3(0f, -3f);
                    path[5] = new Vector3(-2.5f, -4f);
                    path[6] = new Vector3(-6f, -5f);
                }
                if (tempAt == 1)
                {
                    path = new Vector3[7];
                    path[0] = new Vector3(8f, 0f);
                    path[1] = new Vector3(6f, 2f);
                    path[2] = new Vector3(4f, 0f);
                    path[3] = new Vector3(2f, 2f);
                    path[4] = new Vector3(0f, 0f);
                    path[5] = new Vector3(-2.5f, 4f);
                    path[6] = new Vector3(-6f, 5f);
                }
            }
            else if (campaignAt == 2)
            {
                if (tempAt == 0)
                {
                    path = new Vector3[6];
                    path[0] = new Vector3(8f, 0f);
                    path[1] = new Vector3(5f, -1f);
                    path[2] = new Vector3(2f, 4f);
                    path[3] = new Vector3(-1f, 2f);
                    path[4] = new Vector3(-4f, 4f);
                    path[5] = new Vector3(-7f, 6f);
                }
                if (tempAt == 1)
                {
                    path = new Vector3[6];
                    path[0] = new Vector3(8f, -4f);
                    path[1] = new Vector3(5f, -3f);
                    path[2] = new Vector3(2f, -1f);
                    path[3] = new Vector3(-1f, -4f);
                    path[4] = new Vector3(-4f, -1f);
                    path[5] = new Vector3(-7f, -5f);
                }
            }
            else if (campaignAt == 3)
            {
                if(tempAt == 0)
                {
                    path = new Vector3[1];
                    path[0] = new Vector3(-9, 4f);
                }
                if (tempAt == 1)
                {
                    path = new Vector3[1];
                    path[0] = new Vector3(-9, 0f);
                }
                if (tempAt == 2)
                {
                    path = new Vector3[1];
                    path[0] = new Vector3(-9, -4f);
                }
            }
            else if (campaignAt == 4)
            {
                if (tempAt == 0)
                {
                    path = new Vector3[10];
                    path[0] = new Vector3(8, 4f);
                    path[1] = new Vector3(6, 1.5f);
                    path[2] = new Vector3(4, 4f);
                    path[3] = new Vector3(2, 1.5f);
                    path[4] = new Vector3(0, 4f);
                    path[5] = new Vector3(-2, 1.5f);
                    path[6] = new Vector3(-4, 4f);
                    path[7] = new Vector3(-6, 1.5f);
                    path[8] = new Vector3(-8, 4f);
                    path[9] = new Vector3(-10, 1.5f);
                }
                if (tempAt == 1)
                {
                    path = new Vector3[10];
                    path[0] = new Vector3(8, 0f);
                    path[1] = new Vector3(6, 1.5f);
                    path[2] = new Vector3(4, 0f);
                    path[3] = new Vector3(2, -1.5f);
                    path[4] = new Vector3(0, 0f);
                    path[5] = new Vector3(-2, 1.5f);
                    path[6] = new Vector3(-4, 0f);
                    path[7] = new Vector3(-6, -1.5f);
                    path[8] = new Vector3(-8, 0f);
                    path[9] = new Vector3(-10, 1.5f);
                }
                if (tempAt == 2)
                {
                    path = new Vector3[10];
                    path[0] = new Vector3(8, -4f);
                    path[1] = new Vector3(6, -1.5f);
                    path[2] = new Vector3(4, -4f);
                    path[3] = new Vector3(2, -1.5f);
                    path[4] = new Vector3(0, -4f);
                    path[5] = new Vector3(-2, -1.5f);
                    path[6] = new Vector3(-4, -4f);
                    path[7] = new Vector3(-6, -1.5f);
                    path[8] = new Vector3(-8, -4f);
                    path[9] = new Vector3(-10, -1.5f);
                }
            }
        }
    }
}
