using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Gravity : MonoBehaviour
{
    private Vector3 scaleChange;

 
    public List<GameObject> innerObjects;
    

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.layer > 0)
            return;

        Vector3 direction = (BallSpawn.counter < 250) ? other.transform.position - transform.position : transform.position - other.transform.position;
        GetComponent<Rigidbody>().AddForceAtPosition(direction.normalized, transform.position, ForceMode.Force);
    }

    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(rb.velocity.x * 0.01f, rb.velocity.y * 0.01f, rb.velocity.z * 0.01f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (BallSpawn.counter >= Counter.MaxBalls)
            return;

        if (gameObject.layer > 0)
            return;

        if (!gameObject.activeSelf)
        {
            if (innerObjects.Count == 0)
                Destroy(gameObject);
            return;
        }

        var otherBall = collision.gameObject;
        Rigidbody rb = GetComponent<Rigidbody>();

        if (otherBall.activeSelf)
        {
            var addMass = otherBall.GetComponent<Rigidbody>().mass;
            
            rb.mass = rb.mass + addMass;
            var newDiametr = 2 * Mathf.Pow(((3 * rb.mass) / (4 * 3.14f)), 1.0f / 3);
            scaleChange = new Vector3(newDiametr, newDiametr, newDiametr);

            gameObject.transform.localScale = scaleChange;
            otherBall.SetActive(false);



            if (rb.mass >= Counter.CriticalBalls)
            {
                innerObjects.RemoveAll(i => true);
                gameObject.SetActive(false);
                float babah = 10f;
                for (int i = 0; i < rb.mass; i++)
                {
                    GameObject obj = Instantiate(gameObject, transform.position, transform.rotation);
                    obj.SetActive(true);
                    obj.name = "sphere";
                    obj.layer = 8;
                    obj.transform.localScale = new Vector3(1f, 1f, 1f);
                    obj.GetComponent<Rigidbody>().mass = 1f;
                    obj.GetComponent<Gravity>().innerObjects = new List<GameObject>();

                    obj.GetComponent<Rigidbody>().AddExplosionForce(4000f, transform.position + new Vector3(Random.Range(-babah, babah), Random.Range(-babah, babah), Random.Range(-babah, babah)), babah * 200);

                    innerObjects.Add(obj);
                }
                Invoke("ReleaseCollision", 0.5f);
            }
        }
    }

    private void ReleaseCollision()
    {
        
        foreach (GameObject item in innerObjects)
        {
            if (item != null)
                item.layer = 0;
                
        }
        innerObjects.Clear();
        Destroy(gameObject);
    }

}
    