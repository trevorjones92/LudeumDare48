using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public static Obstacles Instance { get; private set; }

    [SerializeField] private float frequency_1 = 1f;
    [SerializeField] private float frequency_2 = 2f;
    [SerializeField] private float frequency_3 = 3f;


    public GameObject obstacle;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance!");
            return;
        }

        Instance = this;      
        InvokeRepeating("SpawnObstacleSprite", frequency_1, frequency_1);
        InvokeRepeating("SpawnObstacleSprite", frequency_2, frequency_2);
        InvokeRepeating("SpawnObstacleSprite", frequency_3, frequency_3);
    }

    void SpawnObstacleSprite()
    {
        float obstacleSpeed = Random.Range(1000f, 1600f);
        Vector2 spawnPosition = SpawnLocation();
        Instantiate(obstacle, spawnPosition, transform.rotation).GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * obstacleSpeed * Time.deltaTime);
    }

    Vector2 SpawnLocation()
    {
        float randYCoord = Random.Range(-13f, 13f);
        return new Vector2(30f, randYCoord);
    }
}
