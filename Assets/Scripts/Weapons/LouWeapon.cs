using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LouWeapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform muzzlePoint;
    // Update is called once per frame
    public GameObject cannonPrefab;
    public GameObject muzzleFlash;

    public float attackRate = 2f;
    public float nextAttackTime = 0f;
    float maxHeat = 100f;
    float currentHeat = 0f;
    float heatUpRate = 5f;

    float cooldownRate = .5f;
    float cooldownTime;
    float staticCoolDownTime = 5f;

    float timeBetweenShots = 0f;

    bool isOverheating = false;

    PlaySound playSound = new PlaySound();
    public AudioSource c_audioSource;

    [SerializeField] Animator animator;


    void Start()
    {
        playSound.audioSource = c_audioSource;
    }

    // public GameObject muzzle;
    void Update()
    {   
        // Flip();
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("shoot"))
            {
                // control how much the player can shoot
                Shoot();
                nextAttackTime = Time.time + 1f / attackRate;
                timeBetweenShots = 0f;
            }
            else if (!Input.GetButtonDown("shoot"))
            {
                timeBetweenShots += 1f;
            }

            if (timeBetweenShots == 1000f)
            {
                Debug.Log("1000 frames since shot fired");
                Cooldown();
            }
        }
    }
    void Shoot()
    {
        if (currentHeat < maxHeat)
        {
            currentHeat += heatUpRate;

            Instantiate(cannonPrefab, firePoint.position, firePoint.rotation);

            animator.SetTrigger("shooting");

            c_audioSource.Play();
        }
        else if (currentHeat >= maxHeat)
        {
            currentHeat = maxHeat;
            isOverheating = true;
            Overheat(currentHeat, isOverheating);
        }
    }

    void Overheat(float heatLevel, bool isOverheating)
    {
        cooldownTime = staticCoolDownTime;
        Debug.Log(currentHeat + " before overheat");
        while (cooldownTime > 0 && currentHeat > 0)
        {
            cooldownTime -= Time.deltaTime;
            currentHeat -= cooldownRate;
            // Debug.Log(cooldownTime + " " + currentHeat);
        }
        // currentHeat = 0;
        Debug.Log(currentHeat + " after overheat");
    }

    void Cooldown()
    {
        Debug.Log(currentHeat + " before cooldown");
        Debug.Log("COOLING DOWN");
        cooldownTime = staticCoolDownTime;
        while (cooldownTime > 0 && !Input.GetButtonDown("shoot") && currentHeat > 0)
        {
            cooldownTime -= Time.deltaTime;
            currentHeat -= cooldownRate;

            if (currentHeat <= 0)
            {
                currentHeat = 0;
            }
        }
        Debug.Log(currentHeat + " after cooldown");
    }

}