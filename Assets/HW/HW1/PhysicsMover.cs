using Unity.VisualScripting;
using UnityEngine;

public class PhysicsMover : MonoBehaviour
{
    public float force = 10f;
    private Rigidbody rb;

    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb.AddForce(transform.forward * force);
        }
    }

    void LateUpdate()
    {
       
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * 0.1f;
        }
    }
}

/*
1. Which function(s) in this script are used incorrectly? 
Update - applying physics
2. What symptoms can result from physics forces in Update() or LateUpdate()? 
Update() or LateUpdate() are frame dependent and not consistent like fixedupdate, making physics inconsistent if implemented there
3. Where should the physics code be placed instead? FixedUpdate()
*/