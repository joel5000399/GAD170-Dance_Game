using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Splashes simple ui elements when certain game events are triggered
/// 
/// Provided with framework, no modification required
/// </summary>
public class UIManager : MonoBehaviour
{
    public GameObject npcLevelUI;
    public GameObject playerXPUI;

    private void Awake()
    {
    }

    private void OnEnable()
    {
        GameEvents.OnPlayerLevelUp += ShowNPCLevelUI;
        GameEvents.OnPlayerGainXP += ShowPlayerXPUI;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerLevelUp -= ShowNPCLevelUI;
        GameEvents.OnPlayerGainXP -= ShowPlayerXPUI;
    }

    void ShowNPCLevelUI(int level)
    {
        StartCoroutine(NPCLevelUI());
    }

    void ShowPlayerXPUI(int xp)
    {
        StartCoroutine(PlayerXPUI(xp));
    }

    IEnumerator NPCLevelUI()
    {
        npcLevelUI.SetActive(true);
        yield return new WaitForSeconds(1f);
        npcLevelUI.SetActive(false);
    }

    IEnumerator PlayerXPUI(int xp)
    {
        int xpDisplay = 1;
        playerXPUI.SetActive(true);
        while (xpDisplay < xp)
        {
            xpDisplay++;
            playerXPUI.GetComponentInChildren<UnityEngine.UI.Text>().text = "+" + xpDisplay.ToString() + "XP";
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        playerXPUI.SetActive(false);
    }
}
