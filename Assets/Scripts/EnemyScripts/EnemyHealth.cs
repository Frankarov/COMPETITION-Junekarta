using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHP;
    [SerializeField]
    private int currentHP;
    public Animator animatorEnemy;
    public bool headshotted;
    public bool isDie;

    [SerializeField]
    private bool bosMerah;

    [SerializeField]
    private bool tank;

    private EnemyMelee enemyMeleeScript;
    private EnemyShooting enemyShootingScript;
    private EnemyMovement enemyMovementScript;

    private void Start()
    {
        currentHP = maxHP;
        if (tank)
        {
            enemyMeleeScript = GetComponent<EnemyMelee>();
            enemyShootingScript = GetComponent<EnemyShooting>();
            enemyMovementScript = GetComponent<EnemyMovement>();
        }
    }

    private void Update()
    {
        if(currentHP <= 0 && !headshotted)
        {
            Die();
        }else if(currentHP <= 0 && headshotted)
        {
            if (bosMerah || tank)
            {
                Die();
            }
            else
            {
                DieHeadshot();
            }
            
        }

        if(tank && currentHP <= 30)
        {
            enemyShootingScript.enabled = false;
            enemyMeleeScript.enabled = true;
            enemyMovementScript.stopDistance = 2;
            animatorEnemy.SetBool("meleePhase", true);
        }


        if (tank || bosMerah && headshotted)
        {
            headshotted = false;
            animatorEnemy.SetBool("isHittedHeadshot", true);
        }
    }

    public void BosMerahTutupAnimHeadshot()
    {
        animatorEnemy.SetBool("isHittedHeadshot", false);
    }

    private void DieHeadshot()
    {
        Destroy(gameObject, 2f);

        animatorEnemy.SetBool("isDieHeadshot", true);
        isDie = true;
    }

    private void Die()
    {
        Destroy(gameObject, 2f);

        animatorEnemy.SetBool("isDie",true);
        isDie = true;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("EnemyTakeDMG");
        currentHP -= damage;
        if (!headshotted)
        {
            animatorEnemy.SetTrigger("isHitted");
        }

        //Invoke("HitAnimationDone", 0.4f);
    }

    public void HitAnimationDone()
    {
        animatorEnemy.SetBool("isShooting", false);
        animatorEnemy.SetTrigger("isHittedDone");
    }

}
