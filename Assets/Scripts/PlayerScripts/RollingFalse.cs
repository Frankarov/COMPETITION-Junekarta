using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingFalse : MonoBehaviour
{

    //public Animator animatorPlayer;     
    public Animator animatorRoll;
    public GameObject[] gameObjectOn;
    public SpriteRenderer playerRoll;
    public Rigidbody2D rb;
    public void DisableRoll()
    {
        //animatorPlayer.SetTrigger("isRollingFalse");
        //animatorPlayer.SetBool("rollingActive",false);
        animatorRoll.SetBool("isRolling", false);
        rb.constraints = RigidbodyConstraints2D.None;
        playerRoll.enabled = false;
        foreach (GameObject obj in gameObjectOn)
        {
            obj.SetActive(true);
        }
    }

}
