using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Shockwave : Ability
{
    [Range(0,2)]
    [SerializeField] float expandRate;
    [SerializeField] float stunTime;

    public GameObject particleSys;
    public BoxCollider collider;
    private GameObject newSys;

    public bool stunActivate = true;

    private List<NPC> enemies = new List<NPC>();

    public override void Activate(GameObject parent)
    {
        newSys = Instantiate(
        particleSys, 
        parent.transform.position, 
        parent.transform.rotation, 
        parent.transform
        );
        stunActivate = true;
    }

    public override void Active(GameObject parent)
    {
        enemies = newSys.GetComponent<StunField>().npcs;
        // Debug.Log(enemies);
        if (stunActivate == true)
        {
            foreach (NPC npc in enemies)
            {
                Debug.Log("health reduced");
                npc.ReduceHealth(10);
                npc.isStunned = true;
                npc.stunTime = stunTime;
            }
            stunActivate = false;
        }
    }
}
