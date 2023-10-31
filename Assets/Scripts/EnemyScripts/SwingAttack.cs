using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwingAttack : MonoBehaviour
{

    public PlayerStat playerStatScript;
    public PlayerKnockBack playerKnockBackScript;
    public EnemyMovement enemyMovementScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("CompareTagPlayer");
            playerStatScript.TakeDamage(10);

            if(enemyMovementScript.horizontalMovement > 0)
            {
                playerKnockBackScript.KnockKanan();
            }else if(enemyMovementScript.horizontalMovement < 0)
            {
                playerKnockBackScript.KnockKiri();
            }



        }
    }


}
