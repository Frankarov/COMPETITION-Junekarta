using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
public class PuzzleSlot : MonoBehaviour, IDropHandler
{
    public int id;
    public PuzzleMoveSystem puzzleMoveSystemScript;
    public PuzzleManager puzzleManagerScript;
    public AudioSource audioLetakPuzzle;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            audioLetakPuzzle.Play();

            if(eventData.pointerDrag.GetComponent<PuzzleMoveSystem>().id == id)
            {
                Debug.Log("PuzzleCorrect");
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
                puzzleMoveSystemScript.enabled = false;
                puzzleManagerScript.puzzleDragDropScore++;
            }
            else
            {
                eventData.pointerDrag.GetComponent<PuzzleMoveSystem>().ResetPosition();
            }

            
        }
    }
}
