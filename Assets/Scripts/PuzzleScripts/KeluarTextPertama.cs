using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeluarTextPertama : MonoBehaviour
{
    public GameObject text;

    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.SetActive(true);
            Invoke("falsetext", 2);
        }
    }

    private void falsetext()
    {
        text.SetActive(false);
        gameObject.SetActive(false);
    }
}
