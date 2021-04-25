using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFuel : MonoBehaviour
{
    [SerializeField] public float shipFuel = 200f;
    [SerializeField] public float distanceTravelled = 0f;
    public Slider slider;

    public void DistanceEngine()
    {
        distanceTravelled = distanceTravelled + 10f * Time.deltaTime;
    }

    public void ConsumeFuel()
    {
        shipFuel = shipFuel - .01f - Mathf.Epsilon;
        Setfuel(shipFuel);
    }
    public void SetMaxFuel(float shipFuel)
    {
        slider.maxValue = shipFuel;
        slider.value = shipFuel;
    }

    public void Setfuel(float shipFuel)
    {
        slider.value = shipFuel;
    }
}
