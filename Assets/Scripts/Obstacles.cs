using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public static Obstacles Instance { get; private set; }

    [SerializeField] private float frequencySmallObstacles = 2f;
    [SerializeField] private float frequencyMediumObstacles = 2f;

    public GameObject obstacle;
    public GameObject[] SmallObstacleObjects;
    public GameObject[] MediumObstacleObject;

    private int randomInt;
    private float obstacleSpeed;


    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance!");
            return;
        }

        Instance = this;
        InvokeRepeating("SpawnSmallObstacles", frequencySmallObstacles, frequencySmallObstacles);
        InvokeRepeating("SpawnMediumObstacles", frequencyMediumObstacles, 1f);
    }

    void SpawnSmallObstacles()
    {
        obstacleSpeed = Random.Range(1000f, 1600f);
        Vector2 spawnPosition = SpawnLocation();
        SelectRandomSmallObstacle();
        Instantiate(obstacle, spawnPosition, transform.rotation).GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * obstacleSpeed * Time.deltaTime);
    }

    void SpawnMediumObstacles()
    {
        obstacleSpeed = Random.Range(1000f, 1600f);
        Vector2 spawnPosition = SpawnLocation();
        SelectRandomMediumObstacle();
        Instantiate(obstacle, spawnPosition, transform.rotation).GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * obstacleSpeed * Time.deltaTime);
    }

    Vector2 SpawnLocation()
    {
        float randYCoord = Random.Range(-13f, 13f);
        return new Vector2(30f, randYCoord);
    }

    void SelectRandomSmallObstacle()
    {
        randomInt = Random.Range(0, SmallObstacleObjects.Length);
        obstacle= SmallObstacleObjects[randomInt];
    }

    void SelectRandomMediumObstacle()
    {
        randomInt = Random.Range(0, MediumObstacleObject.Length);
        obstacle = MediumObstacleObject[randomInt];
    }
}

