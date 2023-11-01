using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{

    public Transform target;
    public GameObject swing;
    public float meleeDuration;
    public float meleeActivation;

    private float timer;
    private bool isMelee;

    private float cooldownTimer;
    public float cooldownDuration;

    public Animator animatorMelee;
    private BoxCollider2D colliderEnemy;

    private void Start()
    {
        colliderEnemy = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        if(cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if(cooldownTimer <= 0)
        {
            float distance = Vector2.Distance(transform.position, target.position);

            if(distance < meleeActivation)
            {
                if (!isMelee)
                {
                    meleeAttack();
                }
                else
                {
                    timer += Time.deltaTime;
                    if(timer > cooldownDuration)
                    {
                        animatorMelee.SetBool("isMelee", false);
                        isMelee = false;
                        cooldownTimer = cooldownDuration;
                    }
                }
            }
        }





    }
    private void meleeAttack()
    {
        animatorMelee.SetBool("isMelee", true);
        timer = 0f;
        
    }

    public void AnimEventColliderBosMerahOff()
    {
        colliderEnemy.enabled = false;
    }

    public void AnimEventColliderBosMerahOn()
    {
        colliderEnemy.enabled = true;
    }

    public void AnimEventSwingTrue()
    {
        swing.SetActive(true);
        isMelee = true;
    }

    public void AnimEventSwingFalse()
    {
        swing.SetActive(false);
        isMelee = false;
        animatorMelee.SetBool("isMelee", false);
    }



}
