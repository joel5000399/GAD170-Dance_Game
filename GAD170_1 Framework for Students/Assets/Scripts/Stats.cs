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
{
    //[HideInInspector]
    public int level;
    //[HideInInspector]
    public int xp;
    //[HideInInspector]
    public int style, luck, rhythm;
    //[HideInInspector]
    public int totalstats;
    //[HideInInspector]
    public int xpneeded;

    private void Awake()
    {
        //assign initial stats
        StatsGenerator.InitialStats(this);
        {
           
        }    
    }
}
