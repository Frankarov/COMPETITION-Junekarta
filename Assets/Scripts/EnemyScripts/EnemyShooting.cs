using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPosition;
    public Transform bulletPosition2;
    public Transform bulletPosition3;
    public Transform player;
    public bool enemySeePlayer;
    public float distance;

    private float timer;
    public Animator animatorEnemy;
    private EnemyHealth enemyHealthScript;
    private EnemyMovement enemyMovementScript;
    public bool isTank;

    private void Start()
    {
        enemyMovementScript = GetComponent<EnemyMovement>();
        enemyHealthScript = GetComponent<EnemyHealth>();
    }

    private void Update()
    {

        distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance <= enemyMovementScript.stopDistance + 1)
        {
            enemySeePlayer = true;
            timer = timer + Time.deltaTime;
            if(timer > 2)
            {
                timer = 0;
                EnemyShoot();
            }
        }
        else
        {
            enemySeePlayer = false;
        }

        

    }

    public void DoneShoot()
    {
        animatorEnemy.SetBool("isShooting", false);
    }

    public void EnemyShoot()
    {
        if(enemyHealthScript.isDie == false)
        {
            Invoke("ShootBullet", 0.2f);
            animatorEnemy.SetBool("isShooting", true);
            Invoke("DoneShoot", 0.5f);
        }
    }

    public void ShootBullet()
    {
        if (isTank)
        {
            Instantiate(bullet, bulletPosition.position, Quaternion.identity);
            Instantiate(bullet, bulletPosition2.position, Quaternion.identity);
            Instantiate(bullet, bulletPosition3.position, Quaternion.identity);
        }
        else
        {
           Instantiate(bullet, bulletPosition.position, Quaternion.identity);
        }
 
    }

}
