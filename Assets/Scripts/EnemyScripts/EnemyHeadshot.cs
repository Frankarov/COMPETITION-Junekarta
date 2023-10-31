using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadshot : MonoBehaviour
{
    public EnemyHealth enemyHealthScript;
    public void HeadshotExecute()
    {
        Debug.Log("HeadshotExecute");
        enemyHealthScript.headshotted = true;
        enemyHealthScript.TakeDamage(150);
    }

}
