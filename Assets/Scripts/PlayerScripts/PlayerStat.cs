using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    public int maxHP;
    [SerializeField]
    private int currentHP;
    public Animator animatorPlayerMati;
    public GameObject[] gameObjectOff;
    public GameObject playerMati;
    public SpriteRenderer playerKenaHit;
    public bool isDie;

    private Shooting shootingScript;

    public Animator animatorHit;

    private void Start()
    {
        shootingScript = GetComponent<Shooting>();
        currentHP = maxHP;
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("PlayerDie");
        isDie = true;
        foreach (GameObject player in gameObjectOff)
        {
            player.SetActive(false);
        }
        playerMati.SetActive(true);
        animatorPlayerMati.SetBool("playerMati", true);

    }

    public void TakeDamage(int damage)
    {
        Debug.Log("PlayerTakeDamage");
        currentHP -= damage;
        animatorHit.SetBool("KenaHit", true);
        playerKenaHit.enabled = true;
        shootingScript.canShoot = false;
        foreach (GameObject player in gameObjectOff)
        {
            player.SetActive(false);
        }
    }

}
