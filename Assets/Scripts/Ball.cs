using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    public float forceStrength = 1f;
    public float angle;
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float xPos = transform.position.x;
        
        if (xPos < 0)
        {
            Vector3 force = new Vector3(forceStrength, 0f, 0f);
            rb.AddForce(force, ForceMode.Impulse);

            //for particle system
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }

        if (xPos >= 0)
        {
            Vector3 force = new Vector3(-forceStrength, 0f, 0f);
            rb.AddForce(force, ForceMode.Impulse);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnCollisionEnter(Collision other)
    {
        //use rigidbody of ball
        //create new velocity, normalize, multiply by speed
        //make speed neg for other way
        //rigidbody is new velocity
        
        if(other.gameObject.CompareTag("Player"))
        {
            
            SphereCollider ballCollider = gameObject.GetComponent<SphereCollider>();
            BoxCollider boxCollider = other.gameObject.GetComponent<BoxCollider>();
            
            Vector3 boxCenter = boxCollider.bounds.center;
            Vector3 ballCenter = ballCollider.bounds.center;
            Vector3 ballDifference = ballCenter - boxCenter;
            
            Vector3 boxMax = ballCollider.bounds.max;
            Vector3 boxDifference = boxMax - boxCenter; // the zero point

            // Vector3 hitPoint = ballDifference / boxDifference; 
            float hitPoint = angle * (ballDifference.y / boxDifference.y);
            // Debug.Log($"{hitPoint}");

            speed = speed * 2;
            Vector3 newVector = new Vector3(-forceStrength + speed, hitPoint, 0).normalized;

            // Vector3 force = new Vector3(-forceStrength, 0f, 0f).normalized;
            
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(newVector * speed, ForceMode.Impulse);
            // rb.linearVelocity = newVector;
            
            //flipping particles
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;

        }

    }
        
}


// float vectorAngle = angle * (ballContact / difference);


        // Rigidbody rb = GetComponent<Rigidbody>();
        // Vector3 newVector = Vector3();
        // rb.AddForce(-velocity * speed, ForceMode.Force);
        
        // Rigidbody rb = GetComponent<Rigidbody>();
        // Vector3 velocity = new Vector3(10f, 0f, 0f).normalized;
        // // Rigidbody rb = GetComponent<Rigidbody>();
        // // rb.linearVelocity =speed;
        // rb.AddForce(-velocity * speed, ForceMode.Force);
        // rb.linearVelocity = 


        
        // rb.linearVelocity = new Vector3 (10f, 0f, 0f);
        // Vector3 move 

        // rb.linearVelocity = 
        
        
        
        // ContactPoint contact = other.contacts[0];
        // // Debug.Log($"{contact}");
        // Vector3 ballContact = contact.point; 

    
        

        //

        // BoxCollider boxCollider = other.gameObject.GetComponent<BoxCollider>();
        // Vector3 boxCenter = boxCollider.bounds.center;
        // // Vector3 boxMin = boxCollider.bounds.min;
        // Vector3 boxMax = boxCollider.bounds.max;

        // float widthFromCenterY = boxMax.y - boxCenter.y;
        // // Debug.Log($"{widthFromCenterY}");
        // // float widthFromCenterX = boxMax.x - boxCenter.x;

        // float widthFromContactY = ballContact.y - boxCenter.y;
        // // Debug.Log($"{widthFromContactY}");
        // // float widthFromContactX = ballContact.x - boxCenter.x;

        // float vectorAngleY = angle * (widthFromCenterY / widthFromContactY);
        // // Debug.Log($"{vectorAngleY}");
        // // float vectorAngleX = angle * (widthFromCenterX / widthFromContactX);

        // // Vector3 up = Vector3.up;
        // // Quaternion Rotation = Quaternion.Euler(0f, vectorAngleY, 0f);
        // // Vector3 newVector = Rotation * up;

        // Vector3 newVector = new Vector3 (0f, vectorAngleY, 0f).normalized;
        // rb.linearVelocity = newVector;


        // static Quaternion Normalize(Quaternion Rotation);
        
        // Vector3 newVector = Rotation * up;
        // static Vector3 Normalize(Vector3 newVector);
        
        // }


        // if (ballContact.x < boxCenter.x)
        // {
        //     float widthFromContactX = ballContact.X - boxCenter.X;
        //     float vectorAngle = -angle * (widthFromCenterX / widthFromContactX);

        //     Vector3 up = Vector3.up;
        //     Quaternion Rotation = Quaternion.Euler(vectorAngle, 0f, 0f);
        //     Vector3 newVector = Rotation * up;
        // }
