using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public GameObject ball;
    public float startTime;
    public float delayTime;
    public static int counter = 0;
    float rand = 15f;

    void Start()
    {
        InvokeRepeating("SpawnBalls", startTime, delayTime);
    }

    public void SpawnBalls()
    {
        if (counter >= Counter.MaxBalls)
        {
            CancelInvoke("SpawnBalls");
        }
        else
        {
            GameObject newBall = Instantiate(ball, transform.position + new Vector3(Random.Range(-rand, rand), Random.Range(-rand, rand), Random.Range(-rand, rand)), transform.rotation);
            newBall.name = $"Ball #{++counter}";
        }
    }
}
