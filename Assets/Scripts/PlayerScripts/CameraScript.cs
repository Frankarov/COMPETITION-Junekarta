using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;  
    public Vector3 offset;
    [SerializeField] private Vector3 desiredPosition;
    void FixedUpdate()
    {
        //if (target == null)
          //  return;

        desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
        //transform.position = smoothedPosition;



    }

    private void Update()
    {
        if (desiredPosition.x <= -44.8f)
        {
            desiredPosition.x = Mathf.Max(desiredPosition.x, -44.8f);
        }
    }

}
