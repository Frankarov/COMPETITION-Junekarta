using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;
    private BoxCollider2D colliderPlayer;
    [SerializeField] private float speed = 3;
    public bool isMoving;
    public bool canMoveYes = true;

    [Header("Dash Components")]
    [SerializeField] private float dashingPower = 7f;
    [SerializeField]  private float dashingTime = 0.2f;
    [SerializeField]  private float dashingCooldown = 1f;
    public SpriteRenderer playerRollSprite;
    public bool canDash = true;
    public bool isDash = false;

    [Header("Animators")]
    public Animator animatorPlayer;
    public Animator animatorRoll;
    public Animator animatorJalan;

    [Header("Scripts References")]
    private Shooting shootingScript;
    private SoundManager sfx;
    private ChangeManager changeManagerScript;
    private PlayerStat playerStatScript;

    [Header("Sound")]
    public AudioSource audioSourceJalan;
    public AudioSource audioSourceRoll;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootingScript = GetComponent<Shooting>();
        colliderPlayer = GetComponent<BoxCollider2D>();
        changeManagerScript = GetComponent<ChangeManager>();
        playerStatScript = GetComponent<PlayerStat>();
        sfx = GetComponent<SoundManager>();
        canMoveYes = true;
    }

    private void FixedUpdate()
    {
        if (!playerStatScript.isDie && canMoveYes)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));
            isMoving = Mathf.Abs(horizontalInput) > 0f;
            animatorJalan.SetBool("isMoving", isMoving);
            AudioJalan();
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

    private void AudioJalan()
    {
        if (isMoving)
        {
            if (!audioSourceJalan.isPlaying && audioSourceJalan != null && audioSourceJalan.enabled)
            {
                audioSourceJalan.pitch = 2f;
                audioSourceJalan.Play();
            }
        }
        else
        {
            audioSourceJalan.pitch = 1f;
            audioSourceJalan.Stop();
        }
    }

    private IEnumerator Dash()
    {
        isDash = true;
        canDash = false;
        shootingScript.canShoot = false;
        colliderPlayer.enabled = false;
        playerRollSprite.enabled = true;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dashDirection = mousePos - transform.position;
        dashDirection.Normalize();
        rb.velocity = dashDirection * dashingPower;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;

        animatorRoll.SetBool("isRolling",true);
        audioSourceRoll.Play();

        changeManagerScript.TurnOff();
        Invoke("RollingDone", 0.5f);

        yield return new WaitForSeconds(dashingTime); ///

        shootingScript.canShoot = true;
        colliderPlayer.enabled = true;
        rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(dashingCooldown); ///

        canDash = true;
        
    }

    private void RollingDone()
    {
        isDash = false;
        changeManagerScript.TurnOn();
        animatorRoll.SetBool("isRolling", false);
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        playerRollSprite.enabled = false;
    }


}
