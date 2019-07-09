using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Force rotation constraint in late update, rotation constraint could also be used.
/// 
/// Provided with framework, no modification required
/// </summary>
public class LockRotation : MonoBehaviour
{
    private Quaternion baseRotation;
    
    void Start()
    {
        baseRotation = transform.rotation;
    }
    
    void LateUpdate()
    {
        transform.rotation = baseRotation;
    }
}
