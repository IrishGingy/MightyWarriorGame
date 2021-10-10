using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Text timeText;

    // obstacle that is shot out.
    [SerializeField] GameObject obstacle;
    [SerializeField] int obstacleCount;

    private Stack<GameObject> obstacles = new Stack<GameObject>();
    private float[] pattern2 = new float[2];
    private float[] pattern3 = new float[2];
    private float[] pattern4 = new float[2];
    private Dictionary<string, Vector3> pattern = new Dictionary<string, Vector3>();
    public float z = 0f;
    public float y = 0f;
    public float lifeSpan = 5f;
    public float launchVelocity = 500f;

    private float timeRemaining = 10;
    private bool timerIsRunning = false;
    public Vector3 spawnPos;
    private bool destroyed = false;
    private GameObject obj = null;

    // Every once in a while a homing obstacle that follows the player?

    private void Start()
    {

        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            obstacle.GetComponent<Rigidbody>().AddExplosionForce(launchVelocity, new Vector3(72f, 0f, 0f), 20f, 10f);
        }
        if (timerIsRunning)
        {
            // Timer functionality.
            if (timeRemaining > 0)
            {
                if (timeRemaining <= 5 && !destroyed && obj != null)
                {
                    for (int i = 0; i < obstacleCount; i++)
                    {
                        Destroy(obstacles.Pop());
                    }
                    destroyed = true;
                }

                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Shooting obstacle...");
                for (int i = 0; i < obstacleCount; i++)
                {
                    z = Random.Range((-gameObject.transform.localScale.z) + (gameObject.transform.localScale.z / 2), gameObject.transform.localScale.z - (gameObject.transform.localScale.z / 2));
                    y = Random.Range(1.5f, gameObject.transform.localScale.y);
                    spawnPos = new Vector3((gameObject.transform.position.x - 2f), y, z);
                    obj = Instantiate(obstacle, spawnPos, gameObject.transform.rotation);
                    obstacles.Push(obj);
                    obj.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                    (-launchVelocity, 0f, 0f));
                }
                
                Debug.Log("Force Applied");
                destroyed = false;
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        else
        {
            timeRemaining = 10;
            timerIsRunning = true;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        //timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;

        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}
