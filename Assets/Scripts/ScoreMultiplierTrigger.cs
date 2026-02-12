using System;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreMultiplierTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        resetScoreMultiplier();
    }

    void OnTriggerEnter(Collider other)
    {
        gameManager.scoreMultiplier();
        gameObject.SetActive(false);
    }

    public void resetScoreMultiplier()
    {
        float xPos = UnityEngine.Random.Range(-5f, 5f);
        float zPos = UnityEngine.Random.Range(3.5f, -4f);
        transform.position = new Vector3 (xPos, 0, zPos);
        gameObject.SetActive(true);
    }
}
