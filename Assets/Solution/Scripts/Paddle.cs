using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class Paddle : MonoBehaviour
{
    public float maxTravelHeight;
    public float minTravelHeight;
    public float speed = 3;
    public float collisionBallSpeedUp = 1.5f;
    
    [SerializeField] InputActionReference inputAction;

    //adding audio 
    public AudioManager audioManager;
    public float audioPitch = 0.6f;

    //adding power ups
    // public PlayerSpeedMultiplerTrigger playerSpeedMult;
    
    void OnEnable()
    {
        inputAction.action.Enable();
    }

    void OnDisable()
    {
        inputAction.action.Disable();
    }

    void Update()
    {
        float direction = inputAction.action.ReadValue<float>();
        Vector3 newPosition = transform.position + new Vector3(0, 0, direction) * speed * Time.deltaTime;
        newPosition.z = Mathf.Clamp(newPosition.z, minTravelHeight, maxTravelHeight);

        transform.position = newPosition;
    }

    void OnCollisionEnter(Collision other)
    {
        // Get world-space bounds
        var paddleBounds = GetComponent<BoxCollider>().bounds;
        
        float paddleCenterZ = paddleBounds.center.z;
        float paddleHalfHeight = paddleBounds.extents.z;
        
        float hitZ = other.GetContact(0).point.z;

        // Get a parameterized value roughly in the -1 to 1 range for where the ball hits
        float normalizedHit = (hitZ - paddleCenterZ) / paddleHalfHeight;
        
        // Cap it so that it stay within range (happens when hitting the corner of the paddle)
        float bounceDirection = Mathf.Clamp(normalizedHit, -1f, 1f);

        // Ideally we would use linearVelocity here.  Unfortunately, it is 0-length during the collision
        Vector3 currentVelocity = other.relativeVelocity;

        // The flipped sign will change the velocity direction appropriately for both paddles
        float newSign = -Mathf.Sign(currentVelocity.x);
        // Debug.Log($"{newSign}");

        // Change the velocity between -60 to 60 degrees based on where it hit the paddle
        //anything higher than 34.17 breaks the physics 
        float newSpeed = Mathf.Clamp(currentVelocity.magnitude * collisionBallSpeedUp, 0, 34);
        float newAngle = 60f * bounceDirection * Mathf.Deg2Rad;
        
        // Calculate new velocity vector - using trig and scaled by new speed
        Vector3 newVelocity = new Vector3(newSign * Mathf.Cos(newAngle), 0f, Mathf.Sin(newAngle)) * newSpeed;
        other.rigidbody.linearVelocity = newVelocity;

        // Debug.DrawRay(other.transform.position, newVelocity, Color.yellow);
        // Debug.Break();


        // adding audio
        // Debug.Log($"{newSpeed}");
        audioPitch = Mathf.Clamp(audioPitch + (audioPitch * newSpeed / 50f), 0.5f, 1.75f);
        // Debug.Log($"{audioPitch}");
        
        if (newSign < 0)
            audioManager.playPaddleRight(audioPitch);
        if (newSign > 0)
            audioManager.playPaddleLeft(audioPitch);
    }

    public void resetPitch()
    {
        audioPitch = 0.6f;
    }

    public void speedMultiplier()
    {
        speed = 8;
    }

    public void resetSpeed()
    {
        speed = 3;
    }
}
