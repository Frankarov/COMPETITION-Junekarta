using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{

    public Transform target;
    public float movementSpeed;
    public float stopDistance;
    public float horizontalMovement;

    private void Update()
    {

        Vector3 direction = (target.position - transform.position).normalized;
        horizontalMovement = direction.x * movementSpeed * Time.deltaTime;

        if (Mathf.Abs(target.position.x - transform.position.x) > stopDistance)
        {
            transform.Translate(new Vector3(horizontalMovement, 0, 0));

            if (horizontalMovement > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (horizontalMovement < 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }


    }


}
