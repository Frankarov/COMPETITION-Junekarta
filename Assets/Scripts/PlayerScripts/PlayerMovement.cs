using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3;

    public GameObject Player;
    public Rigidbody2D rb;
    public Animator animatorJalan;
    public AudioSource audioJalan;


    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));
        bool isMoving = Mathf.Abs(horizontalInput) > 0f;
        animatorJalan.SetBool("isMoving", isMoving);

        if (isMoving)
        {



            //if (!audioJalan.isPlaying)
            //{
                //audioJalan.Play();
            //}
        }
        else
        {
            //audioJalan.Stop();
        }

    }


}
