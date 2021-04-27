using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] bool toggleCollision = true;
    public AudioClip audioClip;
    public AudioSource audioSource;
    public static int PlayerCoins = 10;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin" && toggleCollision)
        {
            audioSource.PlayOneShot(audioClip);
            PlayerCoins = PlayerCoins + 1;
            Destroy(collision.gameObject);
        }
    }
}
