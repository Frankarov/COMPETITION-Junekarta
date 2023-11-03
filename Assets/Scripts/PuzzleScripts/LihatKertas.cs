using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LihatKertas : MonoBehaviour
{
    public PlayerStat playerStatScript;
    public PlayerMovement playerMovementScript;
    public Shooting shootingScript;
    private bool masukCollider;
    private bool masukPuzzle;
    [SerializeField] GameObject keycap;
    [SerializeField] GameObject puzzleCanvas;
    public Animator animatorKertasCode;
    public PuzzleManager puzzleManagerScript;

    private void Update()
    {
        if (masukPuzzle & Input.GetMouseButtonDown(0))
        {
            animatorKertasCode.SetBool("isMuncul", false);
            masukPuzzle = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && masukCollider && !masukPuzzle)
        {
            Debug.Log("Masok");
            puzzleCanvas.SetActive(true);
            animatorKertasCode.SetBool("isMuncul", true);
            masukPuzzle = true;
            playerMovementScript.canMoveYes = false;
            playerMovementScript.canDash = false;
            playerMovementScript.isMoving = false;
            shootingScript.canShoot = false;

        }


        if (playerStatScript.playerDiHit)
        {
            PuzzleClose();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            masukCollider = true;
            keycap.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            masukCollider = false;
            keycap.SetActive(false);
        }
    }

    public void PuzzleClose()
    {
        puzzleCanvas.SetActive(false);
        masukPuzzle = false;
        playerMovementScript.canMoveYes = false;
        playerMovementScript.canDash = false;
        shootingScript.canShoot = true;
        puzzleManagerScript.gembok = true;
    }


}
