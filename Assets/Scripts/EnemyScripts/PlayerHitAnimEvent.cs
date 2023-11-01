using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitAnimEvent : MonoBehaviour
{

    public Animator animatorHit;
    public SpriteRenderer playerKenaHit;
    public GameObject[] gameObjectOn;
    public Shooting shootingScript;
    public void TurnOffAnimHit()
    {
        shootingScript.canShoot = true;
        animatorHit.SetBool("KenaHit", false);
        playerKenaHit.enabled = false;
        foreach (GameObject player in gameObjectOn)
        {
            player.SetActive(true);
        }
    }

}
