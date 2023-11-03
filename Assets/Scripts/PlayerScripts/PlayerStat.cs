using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private int maxHP;
    private BoxCollider2D colliderPlayer;
    private Rigidbody2D rb;
    public int currentHP;
    public bool isDie;
    public bool playerDiHit;


    public GameObject playerMati;
    public SpriteRenderer playerKenaHit;
    
    [Header("Scripts References")]
    private Shooting shootingScript;
    private ChangeManager changeManagerScript;

    [Header("Animators")]
    public Animator animatorHit;
    public Animator animatorPlayerMati;

    [Header("Checkpoint Components")]
    private Vector3 checkpointPosition;


    private void Start()
    {
        shootingScript = GetComponent<Shooting>();
        changeManagerScript = GetComponent<ChangeManager>();
        colliderPlayer = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void SetCheckpointPosition(Vector3 position)
    {
        Debug.Log("Checkpoint Set");
        checkpointPosition = position;
    }

    private void BackToCheckpoint()
    {
        Debug.Log("Back To CheckPoint");
        transform.position = checkpointPosition;
        isDie = false;
        changeManagerScript.TurnOn();
        playerMati.SetActive(false);
        colliderPlayer.enabled = true;
        animatorPlayerMati.SetBool("playerMati", false);

        float timer = 0;
        timer =+ Time.deltaTime;
        if(timer == 3)
        {
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        }
       
    }
    private void Die()
    {
        isDie = true;
        changeManagerScript.TurnOff();
        playerMati.SetActive(true);
        animatorPlayerMati.SetBool("playerMati", true);
        colliderPlayer.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        Invoke("RefillHealth", 1f);
        Invoke("BackToCheckpoint", 3f);

    }

    public void TakeDamage(int damage)
    {
        Debug.Log("PlayerTakeDamage");
        currentHP -= damage;
        animatorHit.SetBool("KenaHit", true);
        playerKenaHit.enabled = true;
        playerDiHit = true;
        shootingScript.canShoot = false;
        changeManagerScript.TurnOff();
        Invoke("TakeDamageDone", 0.15f);
    }

    private void TakeDamageDone()
    {
        animatorHit.SetBool("KenaHit", false);
        playerDiHit = false;
        playerKenaHit.enabled = false;
        shootingScript.canShoot = true;
        changeManagerScript.TurnOn();
    }

    private void RefillHealth()
    {
        currentHP = 100;
    }
}
