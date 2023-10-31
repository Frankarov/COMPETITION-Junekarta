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
                    if(timer > meleeActivation)
                    {
                        isMelee = false;
                        swing.SetActive(false);
                        cooldownTimer = cooldownDuration;
                    }
                }
            }
        }





    }
    private void meleeAttack()
    {
        swing.SetActive(true);
        isMelee = true;
        timer = 0f;
    }




}
