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
    private void Update()
    {

        distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance <= 12)
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

    public void DoneShoot() //animation event
    {
        animatorEnemy.SetBool("isShooting", false);
    }

    public void EnemyShoot()
    {
        Invoke("ShootBullet", 0.2f);
        animatorEnemy.SetBool("isShooting", true);
    }

    public void ShootBullet()
    {
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }

}
