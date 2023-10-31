using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    public int maxHP;
    [SerializeField]
    private int currentHP;

    private void Start()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        if (currentHP < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("PlayerDie");
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("PlayerTakeDamage");
        currentHP -= damage;
    }

}
