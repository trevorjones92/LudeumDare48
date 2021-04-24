using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] float shipThrust = 0f;
    

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            ApplyThrust(Vector2.right);
            rb.velocity = rb.velocity.normalized;
        }
        if (Input.GetKey(KeyCode.A))
        {
            ApplyThrust(Vector2.left);
            rb.velocity = rb.velocity.normalized;
        }
        if (Input.GetKey(KeyCode.W))
        {
            ApplyThrust(Vector2.up);
            rb.velocity = rb.velocity.normalized;
        }
        if (Input.GetKey(KeyCode.S))
        {
            ApplyThrust(Vector2.down);
            rb.velocity = rb.velocity.normalized;
        }
    }

    void ApplyThrust(Vector2 direction)
    {
        rb.AddRelativeForce(direction * shipThrust * Time.deltaTime);
    }

    
        
}
