using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPuzzle : MonoBehaviour
{
    public PlayerStat playerStatScript;
    public PlayerMovement playerMovementScript;
    public Shooting shootingScript;
    private bool masukCollider;
    private bool masukPuzzle;
    [SerializeField] GameObject keycap;
    [SerializeField] GameObject[] puzzleCanvas;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && masukCollider && !masukPuzzle)
        {
            puzzleCanvas[0].SetActive(true);
            puzzleCanvas[1].SetActive(true);
            masukPuzzle = true;
            playerMovementScript.canMoveYes = false;
            playerMovementScript.canDash = false;
            playerMovementScript.isMoving = false;
            shootingScript.canReload = false;
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
        puzzleCanvas[0].SetActive(false);
        puzzleCanvas[1].SetActive(false);
        masukPuzzle = false;
        playerMovementScript.canMoveYes = true;
        playerMovementScript.canDash = true;
        shootingScript.canShoot = true;
        shootingScript.canReload = true;
    }

}
