using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Slider slider;

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
