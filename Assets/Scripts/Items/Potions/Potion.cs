using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Potion")]
public class Potion : Item
{
    public float value;
    public float activeTime;

    public float percentChange;
    public float statChange;

    public int typeNum;

    public bool selected = false;

    Player player;

    public enum PotionType {
        noValue,
        instantHealth,
        instantShield,
        instantEnergy,
        regenHealth,
        regenShield,
        regenEnergy,
        damageReduction
    }

    PotionType state = PotionType.noValue;

    public void Awake()
    {
        type = ItemType.Potion;
    }

    public void SwitchState()
    {
        state = typeNum == 1 ? state = PotionType.instantHealth : state = PotionType.noValue;
        // state = typeNum == 2 ? state = PotionType.instantShield : state = PotionType.noValue;
        // state = typeNum == 3 ? state = PotionType.instantEnergy : state = PotionType.noValue;
        // state = typeNum == 4 ? state = PotionType.regenHealth : state = PotionType.noValue;
        // state = typeNum == 5 ? state = PotionType.regenShield : state = PotionType.noValue;
        // state = typeNum == 6 ? state = PotionType.regenEnergy : state = PotionType.noValue;
        // state = typeNum == 7 ? state = PotionType.damageReduction: state = PotionType.noValue;
        // Debug.Log(state);
    }

    public virtual void Activate(GameObject parent)
    {
        player = parent.GetComponent<Player>();

        switch (state)
        {
            case PotionType.instantHealth:
                GainHealth(player.currentHealth);
            break;
            case PotionType.instantShield:
            break;
            case PotionType.instantEnergy:
            break;
            case PotionType.regenHealth:
            break;
            case PotionType.regenShield:
            break;
            case PotionType.regenEnergy:
            break;
            case PotionType.damageReduction:
            break;
        }
    }

    void GainHealth(float health)
    {
        Debug.Log(health + " " + statChange);
        health += statChange;
        Debug.Log(health + " " + statChange);
        player.healthDisplay.SetHealth(health);
    }

    public virtual void Remove(GameObject parent)
    {

    }
}
