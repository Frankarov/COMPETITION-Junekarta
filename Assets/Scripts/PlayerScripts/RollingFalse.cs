using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingFalse : MonoBehaviour
{

    public Animator animatorPlayer;     

    public void DisableRoll()
    {
        animatorPlayer.SetTrigger("isRollingFalse");
        animatorPlayer.SetBool("rollingActive",false);
    }

}
