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

    [SerializeField] public float frequencySmallObstacles = 2f;
    [SerializeField] public float frequencyMediumObstacles = 3f;
    [SerializeField] public float distanceTravelled = 0f;
    [SerializeField] public float obstacleSpeed = 1500f;
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
        InvokeRepeating("IncreaseLevelDifficulty", 10f, 10f);
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
        obstacleSpeed = ObstacleSpeedOverTime();
        Vector2 spawnPosition = SpawnLocation();
        SelectRandomSmallObstacle();
        Instantiate(obstacle, spawnPosition, transform.rotation).GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * obstacleSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Spawns medium obstacles in the game. These are gameobjects in the GameObjects folder.
    /// </summary>
    void SpawnMediumObstacles()
    {
        obstacleSpeed = ObstacleSpeedOverTime();
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
        ObstacleSpeedOverTime();
    }

    void IncreaseObstacleSpawnRate()
    {
        IsNextLevelOfDifficulty = true;

        if (frequencySmallObstacles >= .2f && frequencyMediumObstacles >= .2f)
        {
            frequencySmallObstacles = frequencySmallObstacles - .2f;
            frequencyMediumObstacles = frequencyMediumObstacles - .2f;
        }
    }

    float ObstacleSpeedOverTime()
    {
        if (obstacleSpeed <= 4000f)
        {
            obstacleSpeed += 300f;
            obstacleSpeed = Random.Range(obstacleSpeed, obstacleSpeed + 300f);
            return obstacleSpeed;
        }
        else
        {
            obstacleSpeed = Random.Range(obstacleSpeed, obstacleSpeed + 300f);
            return obstacleSpeed;
        }
    }
}

