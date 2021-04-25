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
    public Slider slider;
    


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
}
