using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzleRotate : MonoBehaviour, IPointerClickHandler
{

    private RectTransform rectTransform;
    public PuzzleRotateManager puzzleRotateManagerScript;
    public AudioSource audioKlikRotate;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Klikled");
        if (!puzzleRotateManagerScript.isWin)
        {
            rectTransform.Rotate(Vector3.forward, 90f);
            audioKlikRotate.Play();
        }

    }




}
