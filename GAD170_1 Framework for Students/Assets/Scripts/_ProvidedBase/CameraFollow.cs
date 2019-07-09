using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple script based transform offset, intended for camera. Contraints or cinemachine would also be suitable
/// 
/// Provided with framework, no modification required
/// </summary>
public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;

    private Vector3 followPosition;

    private void Awake()
    {
        //Configure before game starts, will just fix to that perspective
        followPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Do we want a deadzone?
        transform.position = followTarget.position + followPosition;
    }
}
