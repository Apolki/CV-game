using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elewator : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public GameObject player;
    public GameObject lift;
    public float speed;
    public ElevatorState state = ElevatorState.MovingTowardsEndPoint;
    public enum ElevatorState
    {
        MovingTowardsStartPoint,
        MovingTowardsEndPoint
    }
    void OnTriggerEnter(Collider other)
    {
        player.transform.parent = lift.transform;
        Debug.Log("Exit");
    }

    public float t;
    void OnTriggerStay(Collider other)
    {

        if (state == ElevatorState.MovingTowardsEndPoint && t < 1.00f)
        {
            t = t + Time.deltaTime * speed;
        }
        if (state == ElevatorState.MovingTowardsStartPoint && t > 0f)
        {
            t = t - Time.deltaTime * speed;
        }
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);
        Debug.Log("Stay");
    }

    void OnTriggerExit(Collider other)
    {
        if (state == ElevatorState.MovingTowardsEndPoint)
        {
            state = ElevatorState.MovingTowardsStartPoint;
        }
        else
        {
            state = ElevatorState.MovingTowardsEndPoint;
        }
        player.transform.parent = null;
        Debug.Log("Exit");
    }
}