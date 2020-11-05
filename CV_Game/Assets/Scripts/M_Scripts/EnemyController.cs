using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform raycastF1;
    [SerializeField] Transform raycastF2;
    [SerializeField] Transform raycastF3;
    [SerializeField] Transform raycastW1;
    [SerializeField] Transform raycastW2;
    [SerializeField] Transform raycastW3;

    public float speed;
    public float distanceF;
    public float distanceW;
    /////////////////////////////////////////////////////////
    [SerializeField] Transform SpawnPoint;
    public float shootrate;
    public float bulletSpeed;
    public float bulletLiveTime;
    private float timestamp;
    public GameObject bulletpref;
    /////////////////////////////////////////////////////////
    public GameObject player;
    public float dist;
    NavMeshAgent nav;
    public float radius;
    public enum enemyState
    {
        calm,
        angry
    }
    public enemyState state = enemyState.calm;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < radius)
            state = enemyState.angry;
        if (dist > radius)
            state = enemyState.calm;
        if (state == enemyState.calm)
        {
            nav.enabled = false;
            float r = Random.Range(-180f, 180f);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
        if (state == enemyState.angry)
        {
            nav.enabled = true;
            nav.SetDestination(player.transform.position);
            if (Time.time > timestamp)
            {
                Fire();
                timestamp = Time.time + shootrate;
            }
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
    void Fire()
    {
        GameObject tempBullet = Instantiate(bulletpref, SpawnPoint.transform.position, SpawnPoint.transform.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
        Destroy(tempBullet, bulletLiveTime);
    }
}
