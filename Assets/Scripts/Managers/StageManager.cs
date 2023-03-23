using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{

    public waveManager wave;
    public Transform cameraMove;

    public GameObject endStageBanner;

    public Canvas canvas;
    public GameObject[] enemies;

    private bool startControl = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextStageControl()
    {
        
        if (startControl)
        {
            Debug.Log("called");
            startControl = false;
            endStageBanner.SetActive(true);
            wave.GetComponent<waveManager>().enabled = false;
        }
    }

    void SafetyDisable()
    {

    }
}
