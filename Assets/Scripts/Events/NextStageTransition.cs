using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class NextStageTransition : MonoBehaviour
{
    [SerializeField] private CodeGameEventListener beginEventListener;
    [SerializeField] private new Transform camera;

    [SerializeField] private GameObject endStageBanner;
    [SerializeField] private CharacterMovement playerMove;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject boss;

    [SerializeField] private PlayerInput player;
    [SerializeField] private LouWeapon weapon;

    private GameObject[] transPoints;

    [SerializeField] private GameObject[] spawnFields;

    [SerializeField] private GameObject activeSpawner;

    private Vector3 target;
    private Vector3 playerMoveTarget;

    private float cameraTarget;

    private int spawnNum = 0;

    private bool shopReached = false;

    private void Start()
    {
        spawnFields = GameObject.FindGameObjectsWithTag("spawnField");

        if (GameStateManager.Instance && GameStateManager.Instance.cameraPos != new Vector3(0,0,0))
        {
            camera.position = GameStateManager.Instance.cameraPos;
            spawnNum = GameStateManager.Instance.spawnNum;
        }
        else
        {
            GameStateManager.Instance.cameraPos = camera.position;
            GameStateManager.Instance.spawnNum = spawnNum;
        }

        for (int i = 0; i < spawnFields.Length; i++)
        {
            if (i != spawnNum) spawnFields[i].SetActive(false);
        }
        spawnNum += 1;

    }

    private void Update()
    {

    }

    private void OnEnable()
    {
        beginEventListener?.OnEnable(OnBeginEventRaised);
    }

    private void findActiveSpawner()
    {
        for (int i = 0; i < spawnFields.Length; i++)
        {
            Debug.Log(spawnNum);
            GameStateManager.Instance.spawnNum = spawnNum;
            if (spawnNum == 2 && !shopReached)
            {
                shopReached = true;
                break;
            }
            if (spawnNum == i && !spawnFields[i].activeSelf)
            {
                spawnFields[i].SetActive(true);
                spawnNum += 1;
                return;
            }
        }
    }

    private void OnBeginEventRaised()
    {
        target = new Vector3(cameraTarget, 1.9f, -1.1f);
        findActiveSpawner();
        // StartCoroutine(MoveOverSpeed(camera, target, 3f));
        endStageBanner.SetActive(false);
    }

    // CAMERA MOVEMENT METHODS

    public IEnumerator MoveOverSpeed(Transform objMov, Vector3 end, float moveSpeed)
     {
        while (objMov.position != end)
        {
            objMov.position = Vector3.MoveTowards(objMov.position, end, moveSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        GameStateManager.Instance.cameraPos = objMov.position;
        cameraTarget = cameraTarget += 10;
        GameStateManager.Instance.st = cameraTarget;
        player.enabled = true;
        weapon.enabled = true;

        findActiveSpawner();
     }

     public IEnumerator MoveOverSeconds(Transform objMov, Vector3 end, float seconds)
     {
        Debug.Log("MOVED IENUMERATOR");
        float elapsedTime = 0;
        Vector3 startPos = objMov.position;
        while (elapsedTime < seconds)
        {
            objMov.position = Vector3.Lerp(startPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objMov.position = end;
     }


}


