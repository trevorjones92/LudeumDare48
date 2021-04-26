using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletPrefab;
    public AudioSource audioSource;
    public AudioClip Shooting;
    public AudioClip Reloading;
    public Text bulletCount;
    public int bullets = 5;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bullets > 0 && Time.timeScale > 0)
        {
            Shoot();
            bullets = bullets - 1;
            audioSource.PlayOneShot(Shooting);
        }
        bulletCount.text = bullets.ToString();
    }
    void Shoot()
    {
        Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ammo" )
        {
            audioSource.PlayOneShot(Reloading);
            bullets = bullets + 5;
            Destroy(collision.gameObject);
        }
    }
}
