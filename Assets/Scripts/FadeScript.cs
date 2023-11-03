using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    private Animator animator;
    public Shooting shooting;
    public PlayerMovement movement;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void AnimEventFade()
    {
        animator.SetTrigger("FadeHitamDone");
        shooting.canShoot = true;
        shooting.canReload = true;
        movement.canDash = true;
        movement.canMoveYes = true;
    }
}
