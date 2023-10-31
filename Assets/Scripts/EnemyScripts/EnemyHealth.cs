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

    private void Start()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        if(currentHP <= 0 && !headshotted)
        {
            Die();
        }else if(currentHP <= 0 && headshotted)
        {
            DieHeadshot();
        }
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
