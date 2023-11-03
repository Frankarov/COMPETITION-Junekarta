using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeManager : MonoBehaviour
{

    public GameObject[] gameObjectOff;
    private PlayerMovement playerMovementScript;
    private PlayerStat playerStatScript;
    private void Start()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
        playerStatScript = GetComponent<PlayerStat>();
    }

    private void Update()
    {
        if(playerStatScript.playerDiHit || playerMovementScript.isDash)
        {
            TurnOff();
        }
    }

    public void TurnOff()
    {
        
        foreach (GameObject objectNya in gameObjectOff)
        {
            objectNya.SetActive(false);
        }
    }

    public void TurnOn()
    {
        if (!playerStatScript.playerDiHit || !playerMovementScript.isDash )
        {
            foreach (GameObject objectNya in gameObjectOff)
            {
            objectNya.SetActive(true);
            }
        }

    }

}
