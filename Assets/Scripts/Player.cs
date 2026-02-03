using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float movementY;
    public float speed = 1f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void OnMovement(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(0.0f, movementY, 0.0f);
    
        rb.linearVelocity = movement * speed;
    }

}
