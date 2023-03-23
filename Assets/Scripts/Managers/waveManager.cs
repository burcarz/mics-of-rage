using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    public string waveName;
    public int enemyCount;
    public GameObject[] enemyTypes;
    public float spawnInterval;
}

public class waveManager : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;
    public GameObject spawnField;
    public Animator anim;
    private int currentWaveNum;
    private Wave currentWave;
    public Text waveName;

    private bool canSpawn = false;
    private bool startSpawn = false;
    private bool canAnimateWave = false;
    public bool stageComplete = true;

    public StageManager stageManager;
    [SerializeField] private EndStageTrigger endStage;


    private float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        // endStage.EndStage();
        StartSpawningWave();
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = waves[currentWaveNum];
        SpawnWave();

        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("enemy");
        if(totalEnemies.Length == 0 && startSpawn)
        {

            if (currentWaveNum + 1 != waves.Length)
            {
                if (canAnimateWave)
                {
                    canAnimateWave = false;
                    SpawnNextWave();
                }
            }
            else
            {
                
                endStage.EndStage();
                this.enabled = false;
                
                return;
            }
        }
    }

    public void SpawnNextWave()
    {
        currentWaveNum++;
        canSpawn = true;
    }

    public void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.enemyTypes[Random.Range(0, currentWave.enemyTypes.Length)];

            // for (int i = 0; i < AIManager.Instance.activeAllies.Count; i++)
            // {
                
            // }
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity, spawnField.transform);
            currentWave.enemyCount--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if (currentWave.enemyCount == 0)
            {
                canSpawn = false;
                canAnimateWave = true;
            }
        }
    }

    public void StartSpawningWave()
    {
        canSpawn = true;
        startSpawn = true;
    }

}
