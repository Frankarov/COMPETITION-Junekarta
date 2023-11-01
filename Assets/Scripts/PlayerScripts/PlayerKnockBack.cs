using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockBack : MonoBehaviour
{

    public float knockbackDuration;
    public float knockbackForce;
    public bool isKnockedBack;
    private Vector3 knockbackDirection;
    private float knockbackStartTime;
    private Rigidbody2D rb;

    public SpriteRenderer player;
    public Shooting shootingScript;
    public PlayerStat playerStatScript;
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
    }

    public void KnockKanan()
    {
        if (!isKnockedBack && playerStatScript.isDie == false)
        {
            Debug.Log("EksekusiKnockbackPlayerKanan");
            knockbackDirection = (transform.position - gameObject.transform.position).normalized;
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
            Debug.Log("EksekusiKnockbackPlayerKiri");
            knockbackDirection = (transform.position - gameObject.transform.position).normalized;
            isKnockedBack = true;
            knockbackStartTime = Time.time;
            rb.AddForce (new Vector2(-1,1) * knockbackForce, ForceMode2D.Impulse);
            shootingScript.canShoot = false;
        }


    }
}
