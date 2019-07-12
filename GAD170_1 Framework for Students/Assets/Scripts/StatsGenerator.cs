using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  A <see langword="static"/> class with methods (functions) for initialising or randomising the stats class.
///  
/// TODO:
///     Initialise a stats instance with generated starting stats
///     Handle the assignment of extra points or xp into an existing stats of a character
///         - this is expected to be used by NPCs leveling up to match the player.
/// </summary>
public static class StatsGenerator
{
    public static void InitialStats(Stats stats)
    
    /* This function sets the base stats for the player when the game starts. It can be set to any value desired to even complex equations.
     * totalstats mentioned in Stats.cs is being used here to add up the three major stats. */
    {
        stats.level = 1;
        stats.xp = 0;
        stats.rhythm = 4;
        stats.style = 7;
        stats.luck = 3;
        stats.xpbar = 100;
        stats.totalstats = (float)(stats.rhythm + stats.style + stats.luck);
                
    }

    public static void GainStats (Stats stats)
    {
        
    }

    public static void AssignUnusedPoints(Stats stats, int points)
    {

    }
}
