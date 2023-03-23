using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDisplay : MonoBehaviour
{
    public Slider slider;

    public void SetMaxEnergy(float energy)
    {
        slider.maxValue = energy;
        slider.value = energy;
    }

    public void SetEnergy(float energy)
    {
        slider.value = energy;
    }
}
