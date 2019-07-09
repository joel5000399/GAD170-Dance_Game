using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple physics velocity movement
/// 
/// Provided with framework, no modification required
/// </summary>
public class PlayerController : MonoBehaviour
{
    Rigidbody body;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Just a rough physics 8 directional for now
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        var desiredDirection = new Vector3(horizontal, 0, vertical);
        if(desiredDirection.magnitude > 1)
        {
            desiredDirection.Normalize();
        }

        body.velocity = desiredDirection * speed * Time.smoothDeltaTime;
        transform.LookAt(transform.position + body.velocity.normalized);
    }
}
