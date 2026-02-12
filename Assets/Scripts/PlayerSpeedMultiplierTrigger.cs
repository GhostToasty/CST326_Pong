using UnityEngine;

public class PlayerSpeedMultiplerTrigger : MonoBehaviour
{
    public Paddle paddleRight;
    public Paddle paddleLeft;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetSpeedMultiplier();
    }

    void OnTriggerEnter(Collider other)
    {
        paddleLeft.speedMultiplier();
        paddleRight.speedMultiplier();
        gameObject.SetActive(false);
    }
    

    public void resetSpeedMultiplier()
    {
        paddleLeft.resetSpeed();
        paddleRight.resetSpeed();
        
        float xPos = UnityEngine.Random.Range(-5f, 5f);
        float zPos = UnityEngine.Random.Range(3.5f, -4f);
        transform.position = new Vector3 (xPos, 0, zPos);
        gameObject.SetActive(true);
    }
}
