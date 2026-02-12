using UnityEngine;

public class BallSizeTrigger : MonoBehaviour
{
    public GameObject ball;
    public float scaleNum;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetBallSize();
    }

    void OnTriggerEnter(Collider other)
    {
        ball.transform.localScale += new Vector3(scaleNum, scaleNum, scaleNum);
        gameObject.SetActive(false);
    }

    public void resetBallSize()
    {
        ball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Debug.Log("reset");
        
        float xPos = UnityEngine.Random.Range(-5f, 5f);
        float zPos = UnityEngine.Random.Range(3.5f, -4f);
        transform.position = new Vector3 (xPos, 0, zPos);
        gameObject.SetActive(true);
    }
}
