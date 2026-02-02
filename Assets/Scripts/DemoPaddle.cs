using UnityEngine;
using UnityEngine.InputSystem;

public class Script : MonoBehaviour
{
    public float paddleSpeed = 1f;
    public float forceStrength = 1f;
    public float maxZ = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //two different ways to code movement 

        ///***///


        // if (Keyboard.current.dKey.isPressed)
        // {
        //     Vector3 force = new Vector3(0f, 0f, forceStrength);
        //     Rigidbody rBody = GetComponent<Rigidbody>();
        //     //acceleration: ignores mass, handles time
        //     //force: takes mass and acceleration into account, handles time
        //     //impulse: for current frame, applies all force immediately, accounts for mass, doesn't handle time
        //     //velocity change: for current frame, applies all force immediately, doesn't account for mass, doesn't handle time 
        //     rBody.AddForce(force, ForceMode.Force);
            
        //     //need to reassign whole vector or variable will be temporary
        //     //needs to be multiplied by time or movement will be based on framerate
        //     //transform makes collision jittery since script runs before rigid body 
        //     // transform.position += new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
        // }

        // if (Keyboard.current.aKey.isPressed)
        // {
        //     Vector3 force = new Vector3(0f, 0f, -forceStrength);
        //     Rigidbody rBody = GetComponent<Rigidbody>();
        //     rBody.AddForce(force, ForceMode.Force);
        //     // transform.position += new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
        // }




        /// **** ///
        
        //allows you to use scale to calculate physics without eyeballing anything
        // BoxCollider boxCollider = GetComponent<BoxCollider>();
        // boxCollider.bounds.
        
        Vector3 newPosition = transform.position + new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
        newPosition.z = Mathf.Clamp(newPosition.z, -10f, maxZ);

        transform.position = newPosition;


        Vector3 up = Vector3.up;
        Quaternion testRotation = Quaternion.Euler(60f, 0f, 1f);

        Vector3 rotatedVector = testRotation * up;
        
        Quaternion otherRotation = Quaternion.Euler(-60f, 0f, 1f);
        Vector3 otherVector = testRotation * up;


        Debug.DrawRay(transform.position, rotatedVector * 5f, Color.red);
        Debug.DrawRay(transform.position, otherVector * 5f, Color.blue);

    }

}
