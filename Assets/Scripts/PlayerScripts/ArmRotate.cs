using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotate : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject outerArmPlayerObject;
    public GameObject innerArmPlayerObject;
    public GameObject pivotDecider;
    public SpriteRenderer torsoPlayer;
    public SpriteRenderer headPlayer;
    public SpriteRenderer innerArmPlayer;
    public SpriteRenderer outerArmPlayer;
    public SpriteRenderer kakiPlayer;
    float rotationZ;

    private void Update()
    {
        //Debug.Log(transform.localEulerAngles.z);
        if(transform.localEulerAngles.z > 80f && transform.localEulerAngles.z < 300f)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 300f);
        }

    }

    private void FixedUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();


        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f,0f,rotationZ);

        if(rotationZ < -90 || rotationZ > 90)
        {
            if(outerArmPlayerObject.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180f,0f,-rotationZ);
            }else if(outerArmPlayerObject.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180f, 180f, -rotationZ);
            }
        }

        if (mousePosition.x < transform.position.x)
        {
            torsoPlayer.flipX = true;
            headPlayer.flipX = true;
            outerArmPlayer.flipX = true;
            innerArmPlayer.flipX = true;
            kakiPlayer.flipX = true;
            transform.localScale = new Vector3(-1, 1, 1);

            cameraTransform.Translate(Vector3.left * 50 * Time.deltaTime);
        }
        else
        {
            torsoPlayer.flipX = false;
            headPlayer.flipX = false;
            outerArmPlayer.flipX = false;
            innerArmPlayer.flipX = false;
            kakiPlayer.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
            cameraTransform.Translate(Vector3.right * 15 * Time.deltaTime);
        }

    }



}
