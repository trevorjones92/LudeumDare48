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

    [SerializeField] private float frequencySmallObstacles = 1.2f;
    [SerializeField] private float frequencyMediumObstacles = 2.2f;
    [SerializeField] private float distanceTravelled = 0f;
    [SerializeField] private float obstacleSpeed;
    private int randomInt;

    public bool IsNextLevelOfDifficulty = false;

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
    }

    void Update()
    {
        DistanceTracker();
        SpawnRateOverTime();

        if (IsNextLevelOfDifficulty)
        {
            CancelInvoke();

            InvokeRepeating("SpawnSmallObstacles", frequencySmallObstacles, frequencySmallObstacles);
            InvokeRepeating("SpawnMediumObstacles", frequencyMediumObstacles, frequencyMediumObstacles);
            IsNextLevelOfDifficulty = false;
        }
    }

    /// <summary>
    /// Spawns medium obstacles in the game. These are gameobjects in the GameObjects folder.
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

    void SelectRandomSmallObstacle()
    {
        randomInt = Random.Range(0, SmallObstacleObjects.Length);
        obstacle = SmallObstacleObjects[randomInt];
    }

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


    // Getting called every frame. Constanly invoking cancel invoke.
    void SpawnRateOverTime()
    {
        if (distanceTravelled < 100f)
        {
           //
        }
        else if (distanceTravelled >= 150f && distanceTravelled <= 151f)
        {
            IsNextLevelOfDifficulty = true;
            frequencySmallObstacles = 1f;
            frequencyMediumObstacles = 2f;
        }
        else if (distanceTravelled >= 201f && distanceTravelled <= 201f)
        {
            IsNextLevelOfDifficulty = true;
            frequencySmallObstacles = .8f;
            frequencyMediumObstacles = 1.8f;
        }
        else if (distanceTravelled >= 250f && distanceTravelled <= 251f)
        {
            IsNextLevelOfDifficulty = true;
            frequencySmallObstacles = .6f;
            frequencyMediumObstacles = 1.6f;
        }
        else if (distanceTravelled >= 300f && distanceTravelled <= 301f)
        {
            IsNextLevelOfDifficulty = true;
            frequencySmallObstacles = .4f;
            frequencyMediumObstacles = 1.4f;
        }
        else if (distanceTravelled >= 350f && distanceTravelled <= 351f)
        {
            IsNextLevelOfDifficulty = true;
            frequencySmallObstacles = .2f;
            frequencyMediumObstacles = 1.2f;
        }
        else if (distanceTravelled >= 400f && distanceTravelled <= 401f)
        {
            IsNextLevelOfDifficulty = true;
            frequencySmallObstacles = .2f;
            frequencyMediumObstacles = 1f;
        }
        else if (distanceTravelled >= 450f && distanceTravelled <= 451f)
        {
            IsNextLevelOfDifficulty = true;
            frequencySmallObstacles = .2f;
            frequencyMediumObstacles = .6f;
        }
        else if (distanceTravelled >= 700f && distanceTravelled <= 701f)
        {
            IsNextLevelOfDifficulty = true;
            frequencySmallObstacles = .2f;
            frequencyMediumObstacles = .4f;
        }
    }

    float ObstacleSpeedOverTime()
    {
        if (distanceTravelled < 100f)
        {
            obstacleSpeed = Random.Range(1800f, 2000f);
            return obstacleSpeed;
        }
        else if (distanceTravelled > 100f && distanceTravelled < 200f)
        {
            obstacleSpeed = Random.Range(2400f, 2800f);
            return obstacleSpeed;
        }
        else if (distanceTravelled > 250f && distanceTravelled < 300f)
        {
            obstacleSpeed = Random.Range(3200f, 3600f);
            return obstacleSpeed;
        }
        else if (distanceTravelled > 500f && distanceTravelled < 700f)
        {
            obstacleSpeed = Random.Range(4000f, 4600f);
            return obstacleSpeed;
        }
        else
        {
            obstacleSpeed = 5000f;
            return obstacleSpeed;
        }
    }
}

