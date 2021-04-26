using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] bool toggleCollision = true;
    public AudioClip audioClip;
    public AudioSource audioSource;
    public static int PlayerCoins;
    
    
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin" && toggleCollision)
        {
            Debug.Log(PlayerCoins);
            audioSource.PlayOneShot(audioClip);
            PlayerCoins = PlayerCoins + 1;
            Destroy(collision.gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
