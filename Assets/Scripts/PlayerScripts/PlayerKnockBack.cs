using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockBack : MonoBehaviour
{
    [Header("Knockback Components")]
    private float knockbackDuration;
    [SerializeField] private float knockbackForce;
    private bool isKnockedBack;
    private float knockbackStartTime;
    

    [Header("References")]
    private Rigidbody2D rb;
    private Shooting shootingScript;
    private PlayerStat playerStatScript;
    private void Update()
    {
        if (isKnockedBack && Time.time - knockbackStartTime > knockbackDuration)
        {
            isKnockedBack = false;
            shootingScript.canShoot = true;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootingScript = GetComponent<Shooting>();
        playerStatScript = GetComponent<PlayerStat>();
    }

    public void KnockKanan()
    {
        if (!isKnockedBack && playerStatScript.isDie == false)
        {
            isKnockedBack = true;
            knockbackStartTime = Time.time;
            rb.AddForce(Vector2.one * knockbackForce, ForceMode2D.Impulse);
            shootingScript.canShoot = false;
            playerStatScript.TakeDamage(30);
        }
    }

    public void KnockKiri()
    {
        if (!isKnockedBack && playerStatScript.isDie == false)
        {
            isKnockedBack = true;
            knockbackStartTime = Time.time;
            rb.AddForce (new Vector2(-1,1) * knockbackForce, ForceMode2D.Impulse);
            shootingScript.canShoot = false;
            playerStatScript.TakeDamage(30);
        }


    }
}
