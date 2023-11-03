using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasukPintuMisterius : MonoBehaviour
{
    public GameObject keycap;
    private bool masukCollider;
    public Animator animatorFade;
    private bool gembok;

    public Transform targetTP;
    public Transform player;

    public Shooting shooting;
    public PlayerMovement playerMovement;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && masukCollider && !gembok)
        {
            animatorFade.SetTrigger("FadeHitamMulai");
            Invoke("TeleportLantai5", 1.3f);
            gembok = true;
            keycap.SetActive(false);
            masukCollider = false;
            shooting.canReload = false;
            shooting.canShoot = false;
            playerMovement.canDash = false;
            playerMovement.canMoveYes = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            keycap.SetActive(true);
            masukCollider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            keycap.SetActive(false);
            masukCollider = false;
        }
    }

    public void TeleportLantai5()
    {
        player.transform.position = targetTP.transform.position;
    }

}
