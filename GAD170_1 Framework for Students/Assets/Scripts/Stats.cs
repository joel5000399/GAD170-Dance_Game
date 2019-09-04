using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the dance stats of a character.
/// 
/// TODO:
///     Nothing, but this class may be a good place to put some helper fuctions when dealing with xp to level conversion and the like.
/// </summary>
public class Stats : MonoBehaviour

/* Everything from line 16-21 was pre-written in the base project file. The only thing I changed was int to float in line 21.
 * I also added lines 23 and 25 to use as variables for calculation in the other scripts. */
{
    //[HideInInspector]
    public int level;
    //[HideInInspector]
    public int xp;
    //[HideInInspector]
    public float style, luck, rhythm;
    //[HideInInspector]
    public float totalstats; 
    //[HideInInspector]
    public float xpbar;
    
    private void Awake()
    {
        //assign initial stats
        StatsGenerator.InitialStats(this);
        {
           
        }    
    }
}
