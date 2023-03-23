using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunField : MonoBehaviour
{
    public List<NPC> npcs = new List<NPC>();
   
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        NPC npc = hitInfo.GetComponent<NPC>();
        
        if (npc != null)
        {
            npcs.Add(npc);
        }
    }
}
