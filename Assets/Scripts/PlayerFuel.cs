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

    private void Start()
    {
        Setfuel(shipFuel);
        audioSource = GetComponent<AudioSource>();
    }

    public void DistanceEngine()
    {
        distanceTravelled = distanceTravelled + 10f * Time.deltaTime;
    }

    public void ConsumeFuel()
    {

        shipFuel = shipFuel - fuelUsageRate - Mathf.Epsilon;
        currentFuel = shipFuel;
        Setfuel(currentFuel);
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
            Debug.Log("Hit fuel canister");
            audioSource.PlayOneShot(audioClip);
            shipFuel = (currentFuel + 50f);
            Destroy(collision.gameObject);
        }
    }
    private void Update()
    {
        if (shipFuel > 100f)
        {
            shipFuel = 100;
        }
    }
}

