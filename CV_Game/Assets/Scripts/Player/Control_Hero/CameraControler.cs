using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    //public float SensitiveX = 3f;
    public float SensitiveY = 3f;

   //public float MinX = -360f;
    //public float MaxX = 360f;
    public float MinY = -80f;
    public float MaxY = 80f;

    private Quaternion originalRot;
    //private float rotX = 0;
    private float rotY = 0;


    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.freezeRotation = true;
        }
        originalRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //rotX += Input.GetAxis("Mouse X") * SensitiveX;
        rotY += Input.GetAxis("Mouse Y") * SensitiveY;

        //rotX = rotX % 360;
        rotY = rotY % 360;

        //rotX = Mathf.Clamp(rotX, MinX, MaxX);
        rotY = Mathf.Clamp(rotY, MinY, MaxY);

        //Quaternion xQuaternion = Quaternion.AngleAxis(rotX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);

        transform.localRotation = originalRot * yQuaternion;


    }
}
