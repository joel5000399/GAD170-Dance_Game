using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple SFX feedback for basic game events
/// 
/// Provided with framework, no modification required
/// </summary>
public class SFXHandler : MonoBehaviour
{
    public AudioClip levelUpClip;
    public AudioClip playerWins;
    public AudioClip playerLoses;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GameEvents.OnBattleConclude += BattleResult;
        GameEvents.OnPlayerLevelUp += LevelUp;
    }

    private void OnDisable()
    {
        GameEvents.OnBattleConclude -= BattleResult;
        GameEvents.OnPlayerLevelUp -= LevelUp;
    }

    public void LevelUp(int level)
    {
        source.PlayOneShot(levelUpClip);
    }

    public void BattleResult(BattleResultEventData data)
    {
        if(data.outcome >= 0)
        {
            source.PlayOneShot(playerWins);
        }
        else
        {
            source.PlayOneShot(playerLoses);
        }
    }
}
