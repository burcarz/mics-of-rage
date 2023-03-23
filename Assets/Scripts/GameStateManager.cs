using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public Character selectedCharacter;

    // PLAYER STATS
    public float playerPoints;
    public float maxHealth;
    public float currentHealth;
    public float maxShields;
    public float currentShields;
    public float maxEnergy;
    public float currentEnergy;

    // PLAYER POSITION
    public Vector3 playerPos;
    public Vector3 cameraPos;

    // PLAYER ITEMS
    public List<Potion> invPotions = new List<Potion>();
    public List<Charm> invCharms = new List<Charm>();
    public List<Ability> invAbilities = new List<Ability>();

    // WAVES
    public GameObject[] spawnFields;
    public GameObject[] transPoints;
    public int pointNum;
    public int spawnNum;
    public float st;

    // MANAGER / ACTIVE ITEMS
    public Potion potion;
    public Ability ability;

    public bool firstLoad = true;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
