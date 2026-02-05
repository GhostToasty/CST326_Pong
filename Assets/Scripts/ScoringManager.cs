using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class ScoringManager : MonoBehaviour
{
    //player 1 = left
    //player 2 = right

    public int player;
    private int score1 = 0;
    private int score2 = 0;
    private string winner;

    public BallSpawner ballSpawner;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (score1 >= 11 || score2 >= 11)
        {   
            Debug.Log($"Game Over!");
            Debug.Log($"{winner} Paddle Wins");
            score1 = 0;
            score2 = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        other.gameObject.SetActive(false);

        if (player == 1)
        {
            score1 = score1 + 1;
            winner = "Right";
            ballSpawner.spawnBall(1/10);
        }
        if (player == 2)
        {
            score2 = score2 + 1;
            winner = "Left";
            ballSpawner.spawnBall(-1/10);
        }

        Debug.Log($"{winner} Paddle scores!");
        Debug.Log($"{score1} -- {score2}");
    } 

}
