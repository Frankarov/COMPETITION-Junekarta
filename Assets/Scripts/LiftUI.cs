using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiftUI : MonoBehaviour
{
    public GameObject canvasLift;
    public Button[] button;
    private int keycard3;
    private int keycard4;
    private bool masukCollider;
    public Transform[] portalLantai;
    public Animator animatorFade;
    public Transform player;
    
    private void Update()
    {
        keycard3 = PlayerPrefs.GetInt("KeyardLantai3");
        keycard4 = PlayerPrefs.GetInt("KeyardLantai4");

        button[0].interactable = true;
        button[1].interactable = true;

        if(keycard3 == 1)
        {
            button[2].interactable = true;
        }

        if(keycard4 == 1)
        {
            button[3].interactable = true;

        }

        if (masukCollider && Input.GetKeyDown(KeyCode.E))
        {
            canvasLift.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            masukCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            masukCollider = false;
            canvasLift.SetActive(false);
        }
    }

    private void ProsedurLift()
    {
        animatorFade.SetTrigger("FadeHitamMulai");
    }

    public void KeLantaiFirst()
    {
        ProsedurLift();
        Invoke("Teleport1", 1.2f);
        
    }
    public void KeLantaiSecond()
    {
        Invoke("Teleport2", 1.2f);
        ProsedurLift();
    }
    public void KeLantaiThird()
    {
        Invoke("Teleport3", 1.2f);
        ProsedurLift();
    }
    public void KeLantaiFourth()
    {
        Invoke("Teleport4", 1.2f);
        ProsedurLift();
    }

    public void Teleport1()
    {
        player.transform.position = portalLantai[0].transform.position;
    }

    public void Teleport2()
    {
        player.transform.position = portalLantai[1].transform.position;
    }

    public void Teleport3()
    {
        player.transform.position = portalLantai[2].transform.position;
    }

    public void Teleport4()
    {
        player.transform.position = portalLantai[3].transform.position;
    }
}
