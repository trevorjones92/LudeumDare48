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

    [SerializeField] private float frequencySmallObstacles = 2f;
    [SerializeField] private float frequencyMediumObstacles = 3f;
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


    // Getting called every frame. Constanly invoking cancel invoke.
    void SpawnRateOverTime()
    {
        if (distanceTravelled < 100f)
        {
            frequencySmallObstacles = 1f;
            frequencyMediumObstacles = 2f;
        }
        else if (distanceTravelled >= 300f && distanceTravelled <= 301f)
        {
            IsNextLevelOfDifficulty = true;
            frequencySmallObstacles = .8f;
            frequencyMediumObstacles = 1.5f;
        }
        else if (distanceTravelled >= 500f && distanceTravelled <= 501f)
        {
            IsNextLevelOfDifficulty = true;
            frequencySmallObstacles = .6f;
            frequencyMediumObstacles = 1f;
        }
        else if (distanceTravelled >= 800f && distanceTravelled <= 801f)
        {
            IsNextLevelOfDifficulty = true;
            frequencySmallObstacles = .4f;
            frequencyMediumObstacles = .8f;
        }
    }

    float ObstacleSpeedOverTime()
    {
        if (distanceTravelled < 100f)
        {
            obstacleSpeed = Random.Range(1500f, 1700f);
            return obstacleSpeed;
        }
        else if (distanceTravelled > 100f && distanceTravelled < 300f)
        {
            obstacleSpeed = Random.Range(1700f, 1900f);
            return obstacleSpeed;
        }
        else if (distanceTravelled > 300f && distanceTravelled < 500f)
        {
            obstacleSpeed = Random.Range(2100f, 2300f);
            return obstacleSpeed;
        }
        else if (distanceTravelled > 500f && distanceTravelled < 700f)
        {
            obstacleSpeed = Random.Range(2300f, 2600f);
            return obstacleSpeed;
        }
        else
        {
            obstacleSpeed = 3000f;
            return obstacleSpeed;
        }
    }
}

