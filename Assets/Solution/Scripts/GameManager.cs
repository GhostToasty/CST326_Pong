using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform ball;
    public float startSpeed = 3f;
    public GoalTrigger leftGoalTrigger;
    public GoalTrigger rightGoalTrigger;

    int leftPlayerScore;
    int rightPlayerScore;
    Vector3 ballStartPos;

    const int scoreToWin = 11;

    //adding audio
    public AudioManager audioManager;
    public Paddle paddleRight;
    public Paddle paddleLeft;

    //adding scoring UI
    public TextMeshProUGUI scoreRight;
    public TextMeshProUGUI scoreLeft;
    private byte redRight = 255;
    private byte greenRight = 0;
    private byte redLeft = 255;
    private byte greenLeft = 0;

    //adding power ups
    private int scoreValue = 1;
    public ScoreMultiplierTrigger multScoreTrigger;
    public PlayerSpeedMultiplerTrigger multSpeedTrigger;
    public BallSizeTrigger ballSizeTrigger;

    //changing color background
    public GameObject background;
    public Material black;
    public Material grid;
    public Material retroTV;
    private Material[] materialArray;
    private int i = 0;
    

    void Start()
    {
        ballStartPos = ball.position;
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        ballBody.linearVelocity = new Vector3(1f, 0f, 0f) * startSpeed;

        scoreRight.color = new Color32(255, 0, 0, 225);
        scoreLeft.color = new Color32(255, 0, 0, 225);

        materialArray = new Material[]{black, grid, retroTV};
        changeBackground();
    }

    public void OnGoalTrigger(GoalTrigger trigger)
    {
        // If the ball entered a goal area, increment the score, check for win, and reset the ball

        if (trigger == leftGoalTrigger)
        {
            rightPlayerScore = rightPlayerScore + scoreValue;
            Debug.Log($"Right player scored: {rightPlayerScore}");

            if (rightPlayerScore == scoreToWin)
            {
                Debug.Log("Right player wins!");
            }
                
            else
                ResetBall(-1f);   

            //adding audio
            audioManager.playWinLeft(); 

            //adding scoring
            string scoreString = $"{rightPlayerScore}";
            scoreRight.text = scoreString;
            greenRight = colorChangeGreen(greenRight);
            redRight = colorChangeRed(greenRight, redRight);
            scoreRight.color = new Color32(redRight, greenRight, 0, 225);
            Debug.Log($"{scoreRight.color}");
        }
        else if (trigger == rightGoalTrigger)
        {
            leftPlayerScore = leftPlayerScore + scoreValue;
            Debug.Log($"Left player scored: {leftPlayerScore}");

            if (leftPlayerScore == scoreToWin)
                Debug.Log("Left player wins!");
            else
                ResetBall(1f);

            //adding audio
            audioManager.playWinRight();

            //adding scoring
            string scoreString = $"{leftPlayerScore}";
            scoreLeft.text = scoreString;
            greenLeft = colorChangeGreen(greenLeft);
            redLeft = colorChangeRed(greenLeft, redLeft);
            scoreLeft.color = new Color32(redLeft, greenLeft, 0, 225);
            Debug.Log($"{scoreLeft.color}");
        }

        //reset pitch after every goal made
        paddleRight.resetPitch();
        paddleLeft.resetPitch();

        //change background
        changeBackground();
    }

    void ResetBall(float directionSign)
    {
        ball.position = ballStartPos;

        // Start the ball within 20 degrees off-center toward direction indicated by directionSign
        directionSign = Mathf.Sign(directionSign);
        Vector3 newDirection = new Vector3(directionSign, 0f, 0f) * startSpeed;
        newDirection = Quaternion.Euler(0f, UnityEngine.Random.Range(-20f, 20f), 0f) * newDirection;

        var rbody = ball.GetComponent<Rigidbody>();
        rbody.linearVelocity = newDirection;
        rbody.angularVelocity = new Vector3();

        // We are warping the ball to a new location, start the trail over
        ball.GetComponent<TrailRenderer>().Clear();

        //reset score value in case of multiplier power up
        scoreValue = 1;
        multScoreTrigger.resetScoreMultiplier();
        multSpeedTrigger.resetSpeedMultiplier();
        ballSizeTrigger.resetBallSize();
    }

    //increases green rgb value on ui when point is scored
    byte colorChangeGreen(byte green)
    {
        if (green < 255)
        {
            //must be converted into bytes to color change, range 0-255
            green = System.Convert.ToByte(Mathf.Clamp(green + (50 * scoreValue), 0, 255));
        }
        return green; 
    }

    //decreases red rgb value on ui when point is scored
    byte colorChangeRed(byte green, byte red)
    {
        if (green == 255 &&  red > 0)
        {
            //must be converted into bytes to color change, range 0-255
            red = System.Convert.ToByte(Mathf.Clamp(red - (50 * scoreValue), 0, 255));
        }
        if (green < 255)
            red = 255;
        
        return red;
    }

    public void scoreMultiplier()
    {
        scoreValue = 2;
    }

    public void changeBackground()
    {
        background.GetComponent<Renderer>().material = materialArray[i];
        i++;
        if (i > 2)
            i = 0;
    }
}
