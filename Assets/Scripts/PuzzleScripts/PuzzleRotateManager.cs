using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRotateManager : MonoBehaviour
{
    [SerializeField] private GameObject puzzleMaket;
    [SerializeField] private RectTransform[] puzzle;
    [SerializeField] private GameObject textKeyCard;
    [SerializeField] private GameObject spriteKeyCard;
    public GameObject colliderPuzzle;
    public ColliderPuzzle colliderPuzzleScript;
    public AudioSource audioGainKeycard;
    private bool gembok;
    public bool isWin;

    private void Update()
    {
        if (puzzle[0].localEulerAngles.z == 0 && puzzle[1].localEulerAngles.z == 180 && puzzle[2].localEulerAngles.z == 180 && !gembok)
        {
            Debug.Log("PuzzleWin");
            Invoke("GainKeyCard", 1f);
            PlayerPrefs.SetInt("KeycardLantai4", 1);
            gembok = true;
            isWin = true;
        }
    }

    private void GainKeyCard()
    {
        textKeyCard.SetActive(true);
        spriteKeyCard.SetActive(true);
        puzzleMaket.SetActive(false);
        audioGainKeycard.Play();
        Invoke("CloseKeyCard", 2f);
    }

    private void CloseKeyCard()
    {
        colliderPuzzleScript.PuzzleClose();
        textKeyCard.SetActive(false);
        spriteKeyCard.SetActive(false);
        colliderPuzzle.SetActive(false);


    }

}
