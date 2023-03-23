using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public Potion potion;
    public float activeTime;
    Player player;
    Inventory inventory;
    
    public enum PotionState {
        idle,
        active,
        used
    }

    
    public bool isIdle = true;
    public bool isUsing = false;
    bool used = false;

    public PotionState state = PotionState.idle;

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.Instance && GameStateManager.Instance.potion)
        {
            potion = GameStateManager.Instance.potion;
        }
        Player player = GetComponent<Player>();
        Inventory inventory = GetComponent<Inventory>();
        switch (state)
        {
            case PotionState.idle:
                if (potion && potion.selected == false)
                {
                    potion.SwitchState();
                }
                else
                {
                    Debug.Log("helasdasd");
                    state = PotionState.active;
                }
            break;
            case PotionState.active:
                if (Input.GetButtonDown("potion") && potion)
                {
                    potion.SwitchState();
                    Debug.Log("POTION CONSUIMED YUM YUM");
                    potion.Activate(gameObject);
                    inventory.UsePotion(potion);
                    state = PotionState.used;
                    used = true;
                }
            break;
            case PotionState.used:
                if (used)
                {
                    potion = null;
                    used = false;
                    state = PotionState.idle;
                }
            break;
        }
    }
}
