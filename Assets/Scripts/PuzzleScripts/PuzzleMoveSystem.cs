using UnityEngine;
using UnityEngine.UI;

public class DragImage : MonoBehaviour
{
    public GameObject correctForm;
    private bool moving;
    private bool finish;

    private float startPosX;
    private float startPosY;
    private Vector3 resetPosition;

    private void Start()
    {
        resetPosition = this.transform.localPosition;
    }

    private void Update()
    {
        if (!finish && moving)
        {
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        float distance = Vector3.Distance(this.transform.position, correctForm.transform.position);

        if (distance <= 0.5f)
        {
            this.transform.position = correctForm.transform.position;
            finish = true;
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
    }
}
