using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] float shipThrust = 1100f;
    Rigidbody2D rb;
    PlayerFuel playerFuel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerFuel = GetComponent<PlayerFuel>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D) && DoesPlayerHaveFuel())
        {
            ApplyThrust(Vector2.right);
            playerFuel.ConsumeFuel();
            rb.velocity = rb.velocity.normalized;
        }
        if (Input.GetKey(KeyCode.A) && DoesPlayerHaveFuel())
        {
            ApplyThrust(Vector2.left);
            playerFuel.ConsumeFuel();
            rb.velocity = rb.velocity.normalized;
        }
        if (Input.GetKey(KeyCode.W) && DoesPlayerHaveFuel())
        {
            ApplyThrust(Vector2.up);
            playerFuel.ConsumeFuel();
            rb.velocity = rb.velocity.normalized;
        }
        if (Input.GetKey(KeyCode.S) && DoesPlayerHaveFuel())
        {
            ApplyThrust(Vector2.down);
            playerFuel.ConsumeFuel();
            rb.velocity = rb.velocity.normalized;
        }
    }

    private void ApplyThrust(Vector2 direction)
    {
        rb.AddRelativeForce(direction * shipThrust * Time.deltaTime);
    }

    private bool DoesPlayerHaveFuel()
    {
        if (playerFuel.shipFuel >= 0)
        {
            return true;
        }
        return false;
    }
}
