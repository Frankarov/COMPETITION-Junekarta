using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
    public GameObject HPBOI;
    public GameObject endingcoy;
    private bool gembok;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !gembok)
        {
            HPBOI.SetActive(false);
            endingcoy.SetActive(true);
            Invoke("hahaha", 10);
            gembok = true;
        }
    }

    private void hahaha()
    {
        SceneManager.LoadScene(0);
    }


}
