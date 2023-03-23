using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NPC : Character
{
    public float maxShields;
    public float currentShields;

    public Text shieldsDisplay;

    public float minDist = 1f;
    public float speed = 2f;
    public float minThreatDist = 3f;
    public float stunTime;
    public float playerThreatValue;

    /* TRANSFORMS AND GAME OBJECTS */
    public Transform player;
    public GameObject character;
    [SerializeField] public SpriteRenderer spriteRenderer;
    public Rigidbody rb;
    public Animator animator;
    public NavMeshAgent agent;
    public HealthDisplay healthDisplay;
    /* TRANSFORMS AND GAME OBJECTS */

    public bool invuln = false;
    public bool facingLeft = true;
    public bool isInjured = false;
    public bool isCriticallyInjured = false;
    public bool isGrunt = false;
    public bool isThug = false;
    public bool isSupport = false;
    public bool isShielded = false;
    public bool isWaiting = false;
    public bool isStunned  = false;

    public int allyCount;
    public int thugNearby;
    public int supportNearby;
    public int hasTakenDamage;
    public int damageTaken;
    public int isAggro;
    public int isFleeing;
    public int playerIsThreat;
    public int sharedZ;
    public int shieldBroken;

    public float distance;
    // public float[] distanceToAllies;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        spriteRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        rb = GetComponentInParent<Rigidbody>();
        currentHealth = maxHealth;
        healthDisplay.SetMaxHealth(maxHealth);
        InvokeRepeating("checkThreatLevel", 1f, 1f);

        if (AIManager.Instance)
        {
            AIManager.Instance.NPCUpdateCount(this);
        }
    }

    public virtual void Update()
    {
        IsAlive();

        Flip(player.position.x);

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

    public void ReduceHealth(float damage)
    {
        if (invuln)
        {
            return;
        }

        if (currentShields > 0)
        {
            ReduceShields(damage);
            shieldsDisplay.text = currentShields.ToString();
            return;
        }
        else if (currentShields <= 0)
        {
            currentShields = 0;
        }

        currentHealth -= damage;
        healthDisplay.SetHealth(currentHealth);

        IEnumerator TakeDamage()
        {
            spriteRenderer.material.SetInt("Hit", 1);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.material.SetInt("Hit", 0);
        }

        StartCoroutine(TakeDamage());


        if (hasTakenDamage == 0)
        {
            this.hasTakenDamage = 1;
            this.damageTaken = 1;
        }
        else
        {
            this.damageTaken += 1;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        if (currentHealth < maxHealth / 2)
        {
            isInjured = true;
        }
        else if (currentHealth < maxHealth / 4)
        {
            isInjured = false;
            isCriticallyInjured = true;
        }
        else
        {
            isInjured = false;
            isCriticallyInjured = false;
        }
    }

    public void ReduceShields(float damage)
    {
        if (invuln)
        {
            return;
        }

        currentShields -= damage;

        IEnumerator TakeShieldDamage()
        {
            shieldBroken = 1;
            yield return new WaitForSeconds(5f);
            shieldBroken = 0;
        }

        StartCoroutine(TakeShieldDamage());
    }

    void Die()
    {
        // calculate points reward on enemy death;
        float pointsChange = Mathf.Round(Random.value / 2 * maxHealth);

        Destroy(gameObject);
        GivePoints(pointsChange);

        AIManager.Instance.NPCRemoveCount(this);
    }

    public void Flip(float target)
    {
        if (target > transform.position.x && facingLeft)
        {
            facingLeft = false;
            transform.Rotate(0f, 180f, 0f);
            spriteRenderer.transform.Rotate(-90f, 0f, 0f);
        }
        else if (target < transform.position.x && !facingLeft)
        {
            facingLeft = true;
            transform.Rotate(0f, 180f, 0f);
            spriteRenderer.transform.Rotate(90f, 0f, 0f);
        }
    }

    void GivePoints(float points)
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        Player playerPoints = player.GetComponent<Player>();
        playerPoints.GainPoints(points);
    }

    public void DistanceToAllies(List<NPC> allies)
    {
        if (allies.Count >= 1)
        {
            foreach (NPC npc in allies)
            {
                if (npc)
                {
                    distance = Vector3.Distance(npc.transform.position, rb.transform.position);
                }
                else
                {
                    AIManager.Instance.NPCRemoveCount(npc);
                }

            }
        }
    }

    public void StunnedControl(float stunTime)
    {
        if (stunTime > 0)
        {
            stunTime -= Time.deltaTime;
        }
        else
        {
            isStunned = false;
        }
    }

    public void checkThreatLevel()
    {
        float threatDist = Vector3.Distance(player.position, rb.transform.position);

        if (player.position.z <= rb.transform.position.z + .5f ||
            player.position.z >= rb.transform.position.z - .5f)
        {
            sharedZ = 1;
        }
        else
        {
            sharedZ = 0;
        }

        if (sharedZ == 1 && threatDist <= minThreatDist)
        {
            playerIsThreat = 1;
        }

        playerThreatValue = Mathf.Abs(threatDist);
        // Debug.Log(this + " has a player-threat value of " + playerThreatValue);

    }
}
