using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PFX for level up
/// 
/// Provided with framework, no modification required
/// </summary>
public class ParticleHandler : MonoBehaviour
{
    private ParticleSystem system;

    // Start is called before the first frame update
    void Awake()
    {
        system = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        GameEvents.OnPlayerLevelUp += Emit;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerLevelUp -= Emit;
    }

    // Update is called once per frame
    void Emit(int xp)
    {
        system.Play();
    }
}
