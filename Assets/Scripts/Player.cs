using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float movementY;
    public float forceStrength = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("start");
    }

    
    // Update is called once per frame
    // void Update()
    // {
    //     // if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
    //     // {
    //     //     Vector3 force = new Vector3(0f, forceStrength, 0f);
    //     //     Rigidbody rBody = GetComponent<Rigidbody>();
    //     //     rBody.AddForce(force, ForceMode.Force);
            
    //     //     //transform makes collision jittery since script runs before rigid body 
    //     //     // transform.position += new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
    //     // }

    //     // if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
    //     // {
    //     //     Vector3 force = new Vector3(0f, -forceStrength, 0f);
    //     //     Rigidbody rBody = GetComponent<Rigidbody>();
    //     //     rBody.AddForce(force, ForceMode.Force);
    //     //     // transform.position += new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
    //     // }

    // }

    void OnMove(InputValue movementValue)
    {
        Debug.Log("start run");
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        movementY = movementVector.y;
        Debug.Log("running");
    }

    private void FixedUpdate()
    {
        Vector3 force = new Vector3(0.0f, movementY * forceStrength, 0.0f);
        
        rb.AddForce(force, ForceMode.Force);
    }

}

//acceleration: ignores mass, handles time
//force: takes mass and acceleration into account, handles time
//impulse: for current frame, applies all force immediately, accounts for mass, doesn't handle time
//velocity change: for current frame, applies all force immediately, doesn't account for mass, doesn't handle time 
