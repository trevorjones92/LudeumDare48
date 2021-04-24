using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSelector : MonoBehaviour
{
    // This int will determine which of the sprites gets Instantiated.
    private int randomInt;

    // This array contains the different sprites.
    public Sprite[] Obstacle_Sprite;

    // Start is called before the first frame update
    void Start()
    {
        randomInt = Random.Range(0, Obstacle_Sprite.Length);
        GetComponent<SpriteRenderer>().sprite = Obstacle_Sprite[randomInt];
    }
}
