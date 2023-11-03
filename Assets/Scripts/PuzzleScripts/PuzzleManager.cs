using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PuzzleManager : MonoBehaviour
{
    public PlayerMovement playerMovementScript;
    public Shooting shootingScript;

    public int puzzleDragDropScore;
    public Image kertasCode;
    public Animator animatorKertasCode;
    private bool kertasCodeLagiMuncul;
    public GameObject canvasPuzzleDragDrop;
    public bool gembok = false;
    public GameObject colliderPuzzleDragDrop;
    public GameObject colliderLihatKertas;

    private AudioSource audioKertas;

    private void Start()
    {
        audioKertas = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(puzzleDragDropScore == 5 && !gembok)
        {
            Debug.Log("MenangPuzzleDragDrop");
            animatorKertasCode.SetBool("isMuncul", true);
            gembok = true;
        }

        if (kertasCodeLagiMuncul)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animatorKertasCode.SetBool("isMuncul", false);
                Invoke("CloseMaket", 1);
            }
        }

    }

    private void CloseMaket()
    {
        canvasPuzzleDragDrop.SetActive(false);
    }

    public void LagiMuncul() //animation event
    {
        audioKertas.Play();
        kertasCodeLagiMuncul = true;
    }

    public void UdahTutup() //animation event
    {
        kertasCodeLagiMuncul = false;
    }

    public void ButtonExitPuzzleDragDrop()
    {
        canvasPuzzleDragDrop.SetActive(false);
        playerMovementScript.canDash = true;
        playerMovementScript.canMoveYes = true;
        shootingScript.canShoot = true;
        shootingScript.canReload = true;
        colliderPuzzleDragDrop.SetActive(false);
        colliderLihatKertas.SetActive(true);
        
    }
    

    public void ButtonExitNormal()
    {
        canvasPuzzleDragDrop.SetActive(false);
        playerMovementScript.canDash = true;
        playerMovementScript.canMoveYes = true;
        shootingScript.canShoot = true;
        shootingScript.canReload = true;
    }
}
