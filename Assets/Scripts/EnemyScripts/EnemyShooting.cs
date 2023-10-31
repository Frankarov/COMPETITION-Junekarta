using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPosition;
    public GameObject player;
    public bool enemySeePlayer;
    public float distance;

    private float timer;
    public Animator animatorEnemy;
    private EnemyHealth enemyHealthScript;
    private EnemyMovement enemyMovementScript;

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
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }

}
