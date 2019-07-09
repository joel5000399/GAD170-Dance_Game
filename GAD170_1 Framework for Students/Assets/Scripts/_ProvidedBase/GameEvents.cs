
/// <summary>
/// Data sent along with the game's Battle events
/// 
/// Provided with framework, no modification required
/// </summary>
[System.Serializable]
public class BattleEventData
{
    public Stats player, npc;

    public BattleEventData(Stats _pStats, Stats _npcStats)
    {
        player = _pStats;
        npc = _npcStats;
    }
}

/// <summary>
/// Data sent along with the game's BattleResult event, the involved parties plus the outcome weighted from -1 to 1.
/// 
/// Provided with framework, no modification required
/// </summary>
[System.Serializable]
public class BattleResultEventData
{
    public Stats player, npc;
    public float outcome;

    public BattleResultEventData(Stats _pStats, Stats _npcStats, float outcomeValue)
    {
        player = _pStats;
        npc = _npcStats;
        outcome = outcomeValue;
    }
}

/// <summary>
/// Central routing for all game events. These are most commonly subscribed to with a += in an OnEnable and then 
/// unsubed in a OnDisable
/// 
/// Provided with framework, no modification required
/// </summary>
public static class GameEvents
{
    #region delegate declares
    public delegate void BattleEvent(BattleEventData data);
    public delegate void BattleResult(BattleResultEventData data);
    public delegate void PlayerLevelledUp(int level);
    public delegate void PlayerGainXP(int XP);
    #endregion


    public static event BattleEvent OnBattleRangeEnter;
    public static void EnteredBattleRange(BattleEventData data)
    {
        if (OnBattleRangeEnter != null)
            OnBattleRangeEnter(data);
    }

    public static event BattleEvent OnBattleRangeExit;
    public static void ExitedBattleRange(BattleEventData data)
    {
        if (OnBattleRangeExit != null)
            OnBattleRangeExit(data);
    }

    public static event BattleEvent OnBattleBegin;
    public static void BeginBattle(BattleEventData data)
    {
        if (OnBattleBegin != null)
            OnBattleBegin(data);
    }

    public static event BattleResult OnBattleConclude;
    public static void FinishedBattle(BattleResultEventData data)
    {
        if(OnBattleConclude != null)
           OnBattleConclude(data);
    }

    public static event PlayerLevelledUp OnPlayerLevelUp;
    public static void PlayerLevelUp(int level)
    {
        if (OnPlayerLevelUp != null)
            OnPlayerLevelUp(level);
    }

    public static event PlayerGainXP OnPlayerGainXP;
    public static void PlayerXPGain(int xp)
    {
        if (OnPlayerGainXP != null)
            OnPlayerGainXP(xp);
    }
}
