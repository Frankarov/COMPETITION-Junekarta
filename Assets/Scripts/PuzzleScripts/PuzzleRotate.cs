using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzleRotate : MonoBehaviour, IPointerClickHandler
{

    private RectTransform rectTransform;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Klikled");
        rectTransform.Rotate(Vector3.forward, 90f);
    }


}
