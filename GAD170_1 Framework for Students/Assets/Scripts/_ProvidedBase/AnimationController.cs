using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Routes physics and game information to to the unity animator on this GO/children
/// 
/// Provided with framework, no modification required
/// </summary>
public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody body;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        body = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        GameEvents.OnBattleBegin += Dance;
        GameEvents.OnBattleConclude += BattleResult;
    }

    private void OnDisable()
    {
        GameEvents.OnBattleBegin -= Dance;
        GameEvents.OnBattleConclude -= BattleResult;
    }

    public void BattleResult(BattleResultEventData data)
    {
        float won = data.player.gameObject == gameObject ? data.outcome : data.outcome * -1;

        if (won > 0)
        {
            anim.SetTrigger("Win");
        }
        else
        {
            anim.SetTrigger("Lose");
        }
    }

    void FixedUpdate()
    {
        anim.SetFloat("Velocity", body.velocity.sqrMagnitude);
    }

    void Dance(BattleEventData data)
    {
        //only dance off if we are the target
        if(data.npc.gameObject == gameObject || data.player.gameObject == gameObject)
            anim.SetTrigger("Dance");
    }
}
