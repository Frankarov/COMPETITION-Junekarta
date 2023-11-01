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
    public Animator animatorEnemy;
    private EnemyHealth enemyHealthScript;
    public int[] distanceStop;

    private void Start()
    {
        System.Random rand = new System.Random();
        stopDistance = rand.Next(distanceStop[0], distanceStop[1]);
        enemyHealthScript = GetComponent<EnemyHealth>();

    }

    private void Update()
    {
        if (enemyHealthScript.isDie == false)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            horizontalMovement = direction.x * movementSpeed * Time.deltaTime;

            float distance = Vector2.Distance(transform.position, target.transform.position);

            if (horizontalMovement > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (horizontalMovement < 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }

            if (Mathf.Abs(target.position.x - transform.position.x) > stopDistance)
            {

                transform.Translate(new Vector3(horizontalMovement, 0, 0));
                animatorEnemy.SetBool("isMoving", true);
            }
            else
            {
                animatorEnemy.SetBool("isMoving", false);
            }
        

        }

    }


}
