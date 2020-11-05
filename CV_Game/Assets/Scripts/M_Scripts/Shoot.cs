using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;
    float bulletSpeed = 1000f;
    public GameObject bullet;
    public float TimeLive = 3f;
    AudioSource shootSound;

    void Start()
    {

        shootSound = GetComponent<AudioSource>();
    }
    void Fire()
    {

        GameObject tempBullet = Instantiate(bullet, SpawnPoint.position, SpawnPoint.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);

        Destroy(tempBullet, TimeLive);

        shootSound.Play();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
}
