using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] float shipThrust = 0f;
    
=======
    [SerializeField] float shipThrust = 1100f;
>>>>>>> 0d2f1605fdcf6afe6cc7bbda67abd4fa4d325b9d

    Rigidbody2D rb;
    PlayerFuel playerFuel;
    bool IsPaused = false;
    public Texture btnTexture;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
       
=======
        playerFuel = GetComponent<PlayerFuel>();
>>>>>>> 0d2f1605fdcf6afe6cc7bbda67abd4fa4d325b9d
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            OnGUI();
            PauseUnPauseGame();
        }

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

        playerFuel.DistanceEngine();
    }

    void ApplyThrust(Vector2 direction)
    {
        rb.AddRelativeForce(direction * shipThrust * Time.deltaTime);
    }

<<<<<<< HEAD
    
        
=======
    bool DoesPlayerHaveFuel()
    {
        if (playerFuel.shipFuel >= 0)
        {
            return true;
        }
        return false;
    }

    void PauseUnPauseGame()
    {
        IsPaused = !IsPaused;
        if (IsPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void OnGUI()
    {

        if (!btnTexture)
        {
            Debug.LogError("Please assign a texture on the inspector");
            return;
        }

        if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
            Debug.Log("Clicked the button with an image");

        if (GUI.Button(new Rect(10, 70, 50, 30), "Click"))
            Debug.Log("Clicked the button with text");
    }
>>>>>>> 0d2f1605fdcf6afe6cc7bbda67abd4fa4d325b9d
}
