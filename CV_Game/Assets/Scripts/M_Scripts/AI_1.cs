using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_1 : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform raycastP;
    [SerializeField] Transform raycastF1;
    [SerializeField] Transform raycastF2;
    [SerializeField] Transform raycastF3;
    [SerializeField] Transform raycastW1;
    [SerializeField] Transform raycastW2;
    [SerializeField] Transform raycastW3;

    public float speed;
    public float distanceP;
    public float distanceF;
    public float distanceW;
    

    void Update()
    {
        float r = Random.Range(-180f, 180f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (isPlayer())
        {

        }
        if (!isFloor1())
        {
            transform.rotation = Quaternion.Euler(0, r, 0);
        }
        if (!isFloor2())
        {
            transform.rotation = Quaternion.Euler(0, r, 0);
        }
        if (!isFloor3())
        {
            transform.rotation = Quaternion.Euler(0, r, 0);
        }
        if (isWall1())
        {
            transform.rotation = Quaternion.Euler(0, r, 0);
        }
        if (isWall2())
        {
            transform.rotation = Quaternion.Euler(0, r, 0);
        }
        if (isWall3())
        {
            transform.rotation = Quaternion.Euler(0, r, 0);
        }
    }
    bool isFloor1()
    {
        return Physics.Raycast(transform.position, raycastF1.transform.forward, distanceF);
    }
    bool isFloor2()
    {
        return Physics.Raycast(transform.position, raycastF2.transform.forward, distanceF);
    }
    bool isFloor3()
    {
        return Physics.Raycast(transform.position, raycastF3.transform.forward, distanceF);
    }
    bool isWall1()
    {
        return Physics.Raycast(transform.position, raycastW1.transform.forward, distanceW);
    }
    bool isWall2()
    {
        return Physics.Raycast(transform.position, raycastW2.transform.forward, distanceW);
    }
    bool isWall3()
    {
        return Physics.Raycast(transform.position, raycastW3.transform.forward, distanceW);
    }
    bool isPlayer()
    {
        return Physics.Raycast(transform.position, raycastP.transform.forward, distanceP);
    }
    
}

