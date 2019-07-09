using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles core of player dance interactions with NPCs
/// 
/// Provided with framework, no modification required
/// </summary>
public class Player : MonoBehaviour
{
    private NPC currentOpponent;
    private Stats myStats;
    private Rigidbody body;
    private PlayerController controller;
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        controller = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();

        myStats = GetComponent<Stats>();
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(currentOpponent != null)
        {
            //currently colliding with an NPC
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(DanceOff()); 
            }
        }
    }

    IEnumerator DanceOff()
    {
        BattleEventData data = new BattleEventData(myStats, currentOpponent.myStats);
        GameEvents.BeginBattle(data);
        controller.enabled = false;
        currentOpponent.transform.LookAt(transform.position);
        body.velocity = Vector3.zero;
        currentOpponent.uiCanvas.SetActive(false);

        yield return new WaitForSeconds(3f);

        currentOpponent.uiCanvas.SetActive(true);
        BattleHandler.Battle(data);
        controller.enabled = true;
        currentOpponent.transform.LookAt(transform.position + Vector3.forward);
    }

    //Check for colliding with NPC, can then interact, 
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<NPC>())
        {
            currentOpponent = other.GetComponent<NPC>();
            currentOpponent.uiCanvas.SetActive(true);
            GameEvents.EnteredBattleRange(new BattleEventData(myStats, currentOpponent.myStats));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<NPC>())
        {
            if(other.GetComponent<NPC>() == currentOpponent)
            {
                GameEvents.ExitedBattleRange(new BattleEventData(myStats, currentOpponent.myStats));
                currentOpponent.uiCanvas.SetActive(false);
                currentOpponent = null;
            }
        }
    }
}
