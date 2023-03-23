using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterShopTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent nEvent;
    [SerializeField] private CodeGameEventListener beginEventListener;
    [SerializeField] GameObject arrow;
    private bool hasGameEvent = true;

    private Transform player;
    public LayerMask playerLayer;
    Player pC;

    public float entryRange = 5f;
    public Transform entryPoint;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;

        hasGameEvent = nEvent != null;

        if (!hasGameEvent)
        {
            Debug.LogWarning("NO GAME EVENT ASSIGNED");
        }
    }

    void Update()
    {
        Collider[] playerCollide = Physics.OverlapSphere(entryPoint.position, entryRange, playerLayer);

        for (int i = 0; i < playerCollide.Length; i++)
        {
            if (playerCollide[i] != null)
            {
                pC = playerCollide[i].GetComponent<Player>();

                arrow.SetActive(true);

                if (Input.GetButtonDown("action"))
                {
                    nEvent.Raise();
                }
            }
            else
            {
                arrow.SetActive(false);
            }
        }
    }

    private void OnEnable()
    {
        beginEventListener?.OnEnable(OnBeginEventRaised);
    }

    private void OnBeginEventRaised()
    {
        GameStateManager.Instance.playerPos = pC.transform.position;
        arrow.SetActive(false);
        SceneManager.LoadScene("Shop");
    }
}
