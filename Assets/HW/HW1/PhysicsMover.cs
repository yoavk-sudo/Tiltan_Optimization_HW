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
