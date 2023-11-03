using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resepsionis : MonoBehaviour
{
    public GameObject image;
    bool canShowCanvas;
    private PlayerMovement player;
    private Shooting playerShooting;
    private PlayerStat playerStatus;
    private void Update()
    {
        if(canShowCanvas && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(true);
            player.canDash = false;
            player.canMoveYes = false;
            playerShooting.canShoot = false;
        }

        if(playerStatus != null)
        {
            if (gameObject.activeInHierarchy && playerStatus.playerDiHit)
            {
                gameObject.SetActive(false);
                player.canDash = true;
                player.canMoveYes = true;
                playerShooting.canShoot = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.CompareTag("Player"))
        {
            
            player = collision.GetComponent<PlayerMovement>();
            playerShooting = collision.GetComponent<Shooting>();
            playerStatus = collision.GetComponent<PlayerStat>();
            canShowCanvas = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            player = null;
            playerShooting = null;
            playerStatus = null;
            canShowCanvas = false;
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
        player.canDash = true;
        player.canMoveYes = true;
        playerShooting.canShoot = true;
    }
}
