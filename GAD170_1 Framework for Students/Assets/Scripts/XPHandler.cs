using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for converting a battle result into xp to be awarded to the player.
/// 
/// TODO:
///     Respond to battle outcome with xp calculation based on;
///         player win 
///         how strong the win was
///         stats/levels of the dancers involved
///     Award the calculated XP to the player stats
///     Raise the player level up event if needed
/// </summary>
public class XPHandler : MonoBehaviour
{

    private void OnEnable()
    {
        GameEvents.OnBattleConclude += GainXP;
    }

    private void OnDisable()
    {
        GameEvents.OnBattleConclude -= GainXP;

    }

    public void GainXP(BattleResultEventData data)
    {
        float PlayerStats = (data.player.style + data.player.luck + data.player.rhythm);
        float Gain = PlayerStats/5;
               
        data.player.rhythm += Random.Range (0, 50 +1);
        data.player.style += data.player.luck * 2;
        data.player.luck += Random.Range(0, 5 + 1);
        data.player.xp += (int)Gain;

        if (data.player.xp > data.player.xpneeded)
        {
            data.player.level += 1;
            data.player.xp = 0;
            data.player.xpneeded *= 2;
        }
          
    }
    //Mathf.Pow (number, raise to number) to square and raise numbers
}
