using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmPivotDecider : MonoBehaviour
{

    public GameObject armPivotKanan;
    public GameObject armPivotKiri;
    public GameObject pivotDecider;

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Mathf.Abs(Vector2.Distance(mousePosition, pivotDecider.transform.position)) < 0.5f
        if (mousePosition.x < pivotDecider.transform.position.x)
        {
            armPivotKanan.SetActive(false);
            armPivotKiri.SetActive(true);
        }
        else
        {
            armPivotKanan.SetActive(true);
            armPivotKiri.SetActive(false);
        }



    }


}
