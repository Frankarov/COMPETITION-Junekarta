using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TembokMisterius : MonoBehaviour
{

    public GameObject keycap;
    private bool masukCollider;
    public Transform lukisan;
    public Animator animatorDinding;
    private bool gembok;
    public GameObject colliderBaru;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && masukCollider && !gembok)
        {
            lukisan.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -45f);
            animatorDinding.SetTrigger("dinding");
            colliderBaru.SetActive(true);
            gembok = true;
            keycap.SetActive(false);
            masukCollider = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            keycap.SetActive(true);
            masukCollider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            keycap.SetActive(false);
            masukCollider = false;
        }
    }

}
