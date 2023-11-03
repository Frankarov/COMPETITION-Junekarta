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
    public GameObject keyCaps;
    public GameObject canvasCats;
    private void Update()
    {
        if(canShowCanvas && Input.GetKeyDown(KeyCode.E))
        {
            image.SetActive(true);
            player.canDash = false;
            player.canMoveYes = false;
            playerShooting.canShoot = false;
            playerShooting.canReload = false;
        }

        if(playerStatus != null)
        {
            if (image.activeInHierarchy && playerStatus.playerDiHit)
            {
                image.SetActive(false);
                player.canDash = true;
                player.canMoveYes = true;
                playerShooting.canShoot = true;
                playerShooting.canReload = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.CompareTag("Player"))
        {
            keyCaps.SetActive(true);
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
           
            keyCaps.SetActive(false);
            player = null;
            playerShooting = null;
            playerStatus = null;
            canShowCanvas = false;
        }
    }

    public void Close()
    {
        
        canvasCats.SetActive(false);
        player.canDash = true;
        player.canMoveYes = true;
        playerShooting.canShoot = true;
        playerShooting.canReload = true;
    }
}
