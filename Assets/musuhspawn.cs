using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musuhspawn : MonoBehaviour
{

    private bool gembok;
    public GameObject[] enemies;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !gembok)
        {
            foreach(GameObject lol in enemies)
            {
                lol.SetActive(true);
            }
            gembok = true;
        }
    }

}
