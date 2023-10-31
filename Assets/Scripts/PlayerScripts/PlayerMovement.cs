using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3;

    public GameObject Player;
    private Rigidbody2D rb;
    public Animator animatorJalan;
    public AudioSource audioJalan;

    private bool canDash = true;
    public bool isDash = false;
    [SerializeField]
    private float dashingPower = 7f;
    [SerializeField]
    private float dashingTime = 0.2f;
    [SerializeField]
    private float dashingCooldown = 1f;
    public Animator animatorPlayer;

    public BoxCollider2D colliderPlayer;

    public GameObject[] offPartRolled;
    private Shooting shootingScript;
    
 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootingScript = GetComponent<Shooting>();
    }

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

    private void Update()
    {

        if (isDash)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }

    }

    private IEnumerator Dash()
    {
        Debug.Log("Dash!");
        isDash = true;
        canDash = false;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        

        Vector3 dashDirection = mousePos - transform.position;
        dashDirection.Normalize();

        rb.velocity = dashDirection * dashingPower;
        colliderPlayer.enabled = false;
        animatorPlayer.SetTrigger("isRolling");
        animatorPlayer.SetBool("rollingActive",true);
        Invoke("TurnOffBadan", 0.2f);
        shootingScript.canShoot = false;


        yield return new WaitForSeconds(dashingTime); //
        shootingScript.canShoot = true;
        colliderPlayer.enabled = true;
        rb.velocity = Vector2.zero;
        animatorPlayer.SetBool("rollingActive", false);
        foreach (GameObject obj in offPartRolled)
        {
            obj.SetActive(true);
        }

        yield return new WaitForSeconds(dashingCooldown); //

        canDash = true;
        isDash = false;
    }

    private void TurnOffBadan() 
    {
        foreach (GameObject obj in offPartRolled)
        {
            obj.SetActive(false);
        }
    }

}
