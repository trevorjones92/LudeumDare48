using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollision : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SpaceDebris")
        {
            audioSource.PlayOneShot(audioClip);
            Invoke("PlayerDeath", .5f);
        }
    }

    void PlayerDeath()
    {
        SceneManager.LoadScene("GameOver");
    }
}
