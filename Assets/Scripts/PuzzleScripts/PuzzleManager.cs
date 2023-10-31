using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PuzzleManager : MonoBehaviour
{

    public int puzzleDragDropScore;
    public Image kertasCode;
    public Animator animatorKertasCode;
    private bool kertasCodeLagiMuncul;
    public GameObject canvasPuzzleDragDrop;
    private bool gembok = false;

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
        kertasCodeLagiMuncul = true;
    }

    public void UdahTutup() //animation event
    {
        kertasCodeLagiMuncul = false;
    }

    public void ButtonExitPuzzleDragDrop()
    {
        canvasPuzzleDragDrop.SetActive(false);
    }

}
