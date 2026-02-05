using UnityEngine;
using UnityEngine.InputSystem;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(ballPrefab);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void spawnBall(float num)
    {
        // Debug.Log($"press");
        Transform myTransform = GetComponent<Transform>();
        // Debug.Log($"{myTransform.position}");
        
        float randomX = num;
        // randomX = 0;
        // float sameY = 0;
        // float sameZ = 0;
        myTransform.position = new Vector3(randomX, 0, 0);
        // Debug.Log(myTransform.position);
        // Debug.Log($"{myTransform.position}");

        Instantiate(ballPrefab, myTransform.position, Quaternion.identity);
        // Debug.Log("spawn");
    }

}












// if (Keyboard.current.spaceKey.isPressed)
        // {
        //     Debug.Log("spawn");
        //     // restart = false; 
            
        //     Transform myTransform = GetComponent<Transform>();
            
        //     float changeX = 0;
        //     // if (winner == "Right")
        //     // {
        //     //     changeX = 5f;
        //     // }
        //     // if (winner == "Left")
        //     // {
        //     //     changeX = -5f;
        //     // }

        //     myTransform.position = new Vector3(changeX, 0, 0);

        //     Instantiate(ballPrefab, myTransform.position, Quaternion.identity);
        // }   

        // if (restart == true)
        // // if (Input.GetKeyDown("space"))
        // {   
            
        //     Debug.Log($"press");
        //     Transform myTransform = GetComponent<Transform>();
        //     // Debug.Log($"{myTransform.position}");
            
        //     float randomX = 0f;
        //     float sameY = myTransform.position.y;
        //     float sameZ = myTransform.position.z;
        //     myTransform.position = new Vector3(randomX, sameY, sameZ);
        //     // Debug.Log($"{myTransform.position}");

        //     Instantiate(ballPrefab, myTransform.position, Quaternion.identity);
        //     // again = false;
        // }
