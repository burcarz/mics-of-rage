using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    public TMP_Text pointsText;
    // Start is called before the first frame update
    public void SetPoints(float points)
    {
        Debug.Log("points set");
        pointsText.text = points.ToString();
    }
}
