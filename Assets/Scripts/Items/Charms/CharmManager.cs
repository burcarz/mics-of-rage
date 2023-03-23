using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharmManager : MonoBehaviour
{
    public Charm charm;
    Player player;

    enum CharmState {
        inactive,
        idle,
        active,
        used
    }

    CharmState state = CharmState.idle;

    // Update is called once per frame
    void Update()
    {
        Player player = GetComponent<Player>();

        switch (state)
        {
            case CharmState.inactive:
                // when the charm is not in the player inventory
            break;
            case CharmState.idle:
                // when the charm is not actively affecting the game state
            break;
            case CharmState.active:
                // when the charm is actively affecting the game state
            break;
            case CharmState.used:
                // if the charm has limited uses and has reached max uses
                    charm.Deactivate(gameObject);
            break;
        }
    }
}
