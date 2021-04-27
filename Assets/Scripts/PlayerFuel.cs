using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFuel : MonoBehaviour
{
    [SerializeField] private float fuelUsageRate = .05f;
    [SerializeField] public float currentFuel;
    [SerializeField] public float shipFuel = 200f;
    [SerializeField] public float distanceTravelled = 0f;
    [SerializeField] bool toggleCollision = true;

    public Slider slider;
    public AudioClip audioClip;
    public AudioSource audioSource;

    void Start()

    {
        Setfuel(shipFuel);
        audioSource = GetComponent<AudioSource>();
    }

    public void ConsumeFuel()
    {
        if (Time.timeScale != 0)
        {
            shipFuel = shipFuel - fuelUsageRate - Mathf.Epsilon;
            currentFuel = shipFuel;
            Setfuel(currentFuel);
        }
    }
    public void SetMaxFuel(float Fuel)
    {
        slider.maxValue = Fuel;
        slider.value = Fuel;
    }

    public void Setfuel(float Fuel)
    {
        slider.value = Fuel;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fuel" && toggleCollision)
        {
            audioSource.PlayOneShot(audioClip);
            shipFuel = (currentFuel + 50f);
            Destroy(collision.gameObject);
            
        }
    }
    void Update()
    {
        if (shipFuel > 100f)
        {
            shipFuel = 100;
        }
    }
}

