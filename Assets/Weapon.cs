using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletPrefab;
    public int Bullets = 5;

    public AudioSource audioSource;
    public AudioClip audioClip;
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
            audioSource.PlayOneShot(audioClip);
            Bullets = Bullets - 1;
            
        }
    }
    void Shoot()
    {
        Instantiate(BulletPrefab , firePoint.position , firePoint.rotation);
    }
}
