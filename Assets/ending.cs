using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
    public GameObject HPBOI;
    public GameObject endingcoy;
    private bool gembok;
    public Shooting shoot;
    public PlayerMovement haha;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !gembok)
        {
            HPBOI.SetActive(false);
            endingcoy.SetActive(true);
            Invoke("hahaha", 10);
            gembok = true;
            haha.canDash = false;
            haha.canMoveYes = false;
            shoot.canReload = false;
            shoot.canShoot = false;


        }
    }

    private void hahaha()
    {
        SceneManager.LoadScene(0);
    }


}
