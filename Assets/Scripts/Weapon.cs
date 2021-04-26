using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletPrefab;
    public int Bullets = 5;

    public AudioSource audioSource;
    public AudioClip Shooting;
    public AudioClip Reloading;
    // Update is called once per frame
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Bullets > 0)
        {
            Shoot();
            Bullets = Bullets - 1;
            audioSource.PlayOneShot(Shooting);
        }
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
            Bullets = Bullets + 5;
            Destroy(collision.gameObject);
        }
    }
}
