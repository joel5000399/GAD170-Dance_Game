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
    
    //This function calculates the experience gain for the player once the game starts to play. Line 22 was not written in the base project file.
    {
        GameEvents.OnBattleConclude += GainXP;
    }

    private void OnDisable()
    
    //This function stops executing the experience gain formula once the game is stopped.
    {
        GameEvents.OnBattleConclude -= GainXP;
    }

    public void GainXP(BattleResultEventData data)

    /* This function includes the formulas to calculate the experience gain as well as the stat bonuses received after each round. It also uses the
     * xpbar function mentioned in Stats.cs and used in StatsGenerator.cs to check if the experience gain has reached the set required experience 
     * to level up. The experience received resets the experience to 0 and increases the required experience based on the formula. */
    {
        double PlayerStats = data.player.style + data.player.rhythm;
        double Gain = (PlayerStats * 1.7);

        data.player.rhythm += Random.Range(0, 20 + 1);
        data.player.style += Random.Range(0, 20 + 1);
        data.player.luck += Random.Range(0, 5 + 1);
        data.player.xp += (int)Gain;

        if (data.player.xp > data.player.xpbar)
        {
            data.player.level += 1;
            data.player.xp = 0;
            data.player.xpbar *= 1.5;
            data.player.rhythm = data.player.style / 1.2;
            data.player.style = data.player.level * 0.3;
        }
        print (data.player.xpbar);
    }
    //Mathf.Pow (number, raise to number) to square and raise numbers
}
