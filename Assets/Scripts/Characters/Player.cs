using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{   
    public float maxEnergy;
    public float currentEnergy;
    public float energyReplenish = .001f;

    public float maxShields;
    public float currentShields;
    public float shieldReplenish = .001f;

    public float points;
    public PlayerPoints pointsText;

    public HealthDisplay healthDisplay;
    public EnergyDisplay energyDisplay;
    public ShieldsDisplay shieldsDisplay;

    Vector3 startPosition;

    public Rigidbody rb;

    public bool invuln;
    [SerializeField] SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer.material.SetInt("Hit", 0);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // fail safe first load instance check
        if (GameStateManager.Instance != null && GameStateManager.Instance.firstLoad)
        {
            Debug.Log("first load");
            currentHealth = maxHealth;
            currentEnergy = maxEnergy;
            currentShields = maxShields;

            GameStateManager.Instance.maxHealth = maxHealth;
            GameStateManager.Instance.maxShields = maxShields;
            GameStateManager.Instance.maxEnergy = maxEnergy;

            startPosition = new Vector3(0, 0, 0);
            GameStateManager.Instance.playerPos = startPosition;
        }

        if (GameStateManager.Instance != null && !GameStateManager.Instance.firstLoad)
        {
            Debug.Log("second load");
            // SET CURRENT STATS FROM GAME STATE
            currentHealth = GameStateManager.Instance.currentHealth;
            currentShields = GameStateManager.Instance.currentShields;
            currentEnergy = GameStateManager.Instance.currentEnergy;

            // SET MAX STATS FROM GAME STATE
            maxHealth = GameStateManager.Instance.maxHealth;
            maxShields = GameStateManager.Instance.maxShields;
            maxEnergy = GameStateManager.Instance.maxEnergy;


            
            //  SET POINTS FROM GAME STATE
            points = GameStateManager.Instance.playerPoints;

            // SET STATS TO MAX
            currentHealth = maxHealth;
            currentEnergy = maxEnergy;
            currentShields = maxShields;

            startPosition = GameStateManager.Instance.playerPos;
        }

        healthDisplay.SetMaxHealth(maxHealth);
        energyDisplay.SetMaxEnergy(maxEnergy);
        shieldsDisplay.SetMaxShields(maxShields);

        InvokeRepeating("ReplenishEnergy", .1f, .5f);
        InvokeRepeating("ReplenishShields", .1f, .5f);

        pointsText.SetPoints(points);

        GameStateManager.Instance.firstLoad = false;

        transform.position = startPosition;
        
    }

    // Update is called once per frame
    protected void Update()
    {
        IsAlive();
        if (Input.GetButtonDown("damage"))
        {
            ReduceHealth(20);
        }
    }
 

    public void ReduceHealth(float damage)
    {
        // Debug.Log(damage);
        if (invuln)
        {
            return;
        }

        if (currentShields > 0)
        {
            ReduceShields(damage);
            StartCoroutine(TakeDamage());
            return;
        }

        IEnumerator TakeDamage()
        {
            spriteRenderer.material.SetInt("Hit", 1);
            invuln = true;
            yield return new WaitForSeconds(0.1f);
            invuln = false;
            spriteRenderer.material.SetInt("Hit", 0);
        }

        StartCoroutine(TakeDamage());

        currentHealth -= damage;
        healthDisplay.SetHealth(currentHealth);
    }

    public void ReduceEnergy(float energy)
    {
        currentEnergy -= energy;
        energyDisplay.SetEnergy(currentEnergy);
    }

    public void ReduceShields(float shieldDamage)
    {
        currentShields -= shieldDamage;
        shieldsDisplay.SetShields(currentShields);
    }

    void ReplenishEnergy()
    {
        // Debug.Log("called " + energy);
        if (currentEnergy <= maxEnergy)
        {
            currentEnergy += energyReplenish;
            energyDisplay.SetEnergy(currentEnergy);
        }
    }

    void ReplenishShields()
    {
        // Debug.Log("called " + energy);
        if (currentShields <= maxShields)
        {
            currentShields += shieldReplenish;
            shieldsDisplay.SetShields(currentShields);
        }
    }

    public void GainPoints(float pointsChange)
    {
        points += pointsChange;
        GameStateManager.Instance.playerPoints = points;
        pointsText.SetPoints(points);
    }

    public bool IsAlive()
    {   
        if (currentHealth <= 0)
        {  
            currentHealth = 0;
            Die();
            return false;
        }
        return true;
    }
    
    void Die()
    {
        Destroy(gameObject);
    }
}
