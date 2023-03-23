using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldsDisplay : MonoBehaviour
{
    public Slider slider;

    public void SetMaxShields(float shields)
    {
        slider.maxValue = shields;
        slider.value = shields;
    }

    public void SetShields(float shields)
    {
        slider.value = shields;
    }
}
