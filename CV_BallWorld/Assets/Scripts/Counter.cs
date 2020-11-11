using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text ballsGeneratedText;
    public Text ballsOnAirText;

    public uint maxBalls;
    public uint criticalBalls;

    public static uint MaxBalls;
    public static uint CriticalBalls;

    private void Start()
    {
        MaxBalls = maxBalls;
        CriticalBalls = criticalBalls;
        Physics.IgnoreLayerCollision(0, 8);
    }

    void Update()
    {
        ballsGeneratedText.text = $"{BallSpawn.counter} balls generated";
        if (BallSpawn.counter >= MaxBalls)
            ballsGeneratedText.color = Color.red;

        ballsOnAirText.text = $"{FindObjectsOfType(typeof(Gravity)).Length} balls on-air";

    }
}

