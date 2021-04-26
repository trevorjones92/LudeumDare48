using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public static Obstacles Instance { get; private set; }
    public GameObject obstacle;
    public GameObject[] SmallObstacleObjects;
    public GameObject[] MediumObstacleObject;
    public bool IsNextLevelOfDifficulty = false;
    private int randomInt;

    public float obstacleSpeed = 1000f;
    public float minObstacleSpeed = 200f;
    public float maxObstacleSpeed = 200f;

    [SerializeField] public float frequencySmallObstacles = 2f;
    [SerializeField] public float frequencyMediumObstacles = 2.5f;
    [SerializeField] public float distanceTravelled = 0f;
    [SerializeField] public float distanceIncrementer = 0f;

    /// <summary>
    /// This starts on game start instance. Invokes methods to run evert X amount of seconds.
    /// </summary>
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance!");
            return;
        }

        Instance = this;

        InvokeRepeating("SpawnSmallObstacles", frequencySmallObstacles, frequencySmallObstacles);
        InvokeRepeating("SpawnMediumObstacles", frequencyMediumObstacles, frequencyMediumObstacles);
        InvokeRepeating("IncreaseLevelDifficulty", 1f, 10f);
    }

    void Update()
    {
        DistanceTracker();

        if (IsNextLevelOfDifficulty)
        {
            CancelInvoke();

            InvokeRepeating("SpawnSmallObstacles", frequencySmallObstacles, frequencySmallObstacles);
            InvokeRepeating("SpawnMediumObstacles", frequencyMediumObstacles, frequencyMediumObstacles);
            InvokeRepeating("IncreaseLevelDifficulty", 10f, 10f);
            IsNextLevelOfDifficulty = false;
        }
    }

    /// <summary>
    /// Spawns small obstacles in the game. These are gameobjects in the GameObjects folder.
    /// </summary>
    void SpawnSmallObstacles()
    {
        obstacleSpeed = ObstacleSpeed();
        Vector2 spawnPosition = SpawnLocation();
        SelectRandomSmallObstacle();
        Instantiate(obstacle, spawnPosition, transform.rotation).GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * obstacleSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Spawns medium obstacles in the game. These are gameobjects in the GameObjects folder.
    /// </summary>
    void SpawnMediumObstacles()
    {
        obstacleSpeed = ObstacleSpeed();
        Vector2 spawnPosition = SpawnLocation();
        SelectRandomMediumObstacle();
        Instantiate(obstacle, spawnPosition, transform.rotation).GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * obstacleSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Sets the spawn location of all objets. Spawne on the X axis out of view of the player.
    /// </summary>
    /// <returns></returns>
    Vector2 SpawnLocation()
    {
        float randYCoord = Random.Range(-13f, 13f);
        return new Vector2(40f, randYCoord);
    }

    /// <summary>
    /// Randomly selects a small sized obstacle from a range of given gameobjects
    /// </summary>
    void SelectRandomSmallObstacle()
    {
        randomInt = Random.Range(0, SmallObstacleObjects.Length);
        obstacle = SmallObstacleObjects[randomInt];
    }

    /// <summary>
    /// Randomly selects a medium sized obstacle from a range of given gameobjects
    /// </summary>
    void SelectRandomMediumObstacle()
    {
        randomInt = Random.Range(0, MediumObstacleObject.Length);
        obstacle = MediumObstacleObject[randomInt];
    }

    public float DistanceTracker()
    {
        distanceTravelled = distanceTravelled + 10f * Time.deltaTime;
        return distanceTravelled;
    }

    void IncreaseLevelDifficulty()
    {
        IncreaseObstacleSpawnRate();
        IncreaseObstacleSpeed();
    }

    void IncreaseObstacleSpawnRate()
    {
        IsNextLevelOfDifficulty = true;

        if (frequencySmallObstacles >= .2f && frequencyMediumObstacles >= .2f)
        {
            frequencySmallObstacles = frequencySmallObstacles - .2f;
            frequencyMediumObstacles = frequencyMediumObstacles - .1f;
        }
    }

    float ObstacleSpeed()
    {
        obstacleSpeed = Random.Range(minObstacleSpeed, maxObstacleSpeed);
        return obstacleSpeed;
    }

    void IncreaseObstacleSpeed()
    {
        if (maxObstacleSpeed < 500f)
        {
            minObstacleSpeed += 50f;
            maxObstacleSpeed += 100f;
        }
        if (maxObstacleSpeed < 650f)
        {
            minObstacleSpeed += 15f;
            maxObstacleSpeed += 25f;
        }
        if (maxObstacleSpeed < 800f)
        {
            minObstacleSpeed += 10f;
            maxObstacleSpeed += 20f;
        }
    }
}

