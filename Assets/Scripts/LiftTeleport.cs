using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftTeleport : MonoBehaviour
{
    public GameObject keycap;
    private bool masukCollider;
    public Transform player;
    public Animator animatorFade;
    public Transform portal;
    public Camera cameraMain;

    public Shooting shooting;
    public PlayerStat playerStat;
    public PlayerMovement playerMovement;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && masukCollider)
        {
            animatorFade.SetTrigger("FadeHitamMulai");
            Invoke("PindahLift", 1.3f);
            shooting.canShoot = false;
            playerMovement.canDash = false;
            playerMovement.canMoveYes = false;
            shooting.canReload = false;


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

    public void PindahLift()
    {
        player.position = portal.position;
        cameraMain.backgroundColor = Color.black;
    }
}
