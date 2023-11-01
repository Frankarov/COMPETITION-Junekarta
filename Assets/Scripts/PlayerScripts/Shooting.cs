using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class Shooting : MonoBehaviour
{
    //Shooting Mechanics
    public event EventHandler<OnShootEventArgs> OnShoot;
    public Transform aimTransform;
    private Transform aimGunEndPointTransform;
    private GameObject aimGunEndPointObject;

    //References
    private PlayerMovement playerMovementScript;
    private SoundManager sfx;

    //Essentials
    [SerializeField]
    private int bulletCount = 17;
    private bool isReloading = false;
    public bool canShoot = true;


    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }

    private void Start()
    {
        canShoot = true;
        playerMovementScript = GetComponent<PlayerMovement>();
        sfx = GetComponent<SoundManager>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine(ReloadProcess(1f));
        }

        EksekusiNembak();

    }

    private void Shoot()
    {
        aimGunEndPointObject = GameObject.Find("GunEndPointPosition");
        aimGunEndPointTransform = aimGunEndPointObject.transform;
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        OnShoot?.Invoke(this, new OnShootEventArgs
        {
            gunEndPointPosition = aimGunEndPointTransform.position,
            shootPosition = mousePosition,
        });

        MekanikTembak();
        MekanikHeadshot();
        bulletCount--;
        UtilsClass.ShakeCamera(0.05f, 0.15f);
        
    }

    private void EksekusiNembak()
    {
        if (Input.GetMouseButtonDown(0) && canShoot && bulletCount > 0 && !isReloading)
        {
            Shoot();
            sfx.audioSource.clip = sfx.audioClip[1];
            sfx.audioSource.Play();

        }
        else if (Input.GetMouseButtonDown(0) && canShoot && bulletCount <= 0 && !isReloading)
        {
            sfx.audioSource.clip = sfx.audioClip[2];
            sfx.audioSource.Play();
        }
    }

    private IEnumerator ReloadProcess(float reloadTime)
    {
        sfx.audioSource.clip = sfx.audioClip[0];
        sfx.audioSource.Play();
        sfx.audioSource.pitch = 0.6f;
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        bulletCount = 17;
        isReloading = false;
        sfx.audioSource.pitch = 1f;
        Debug.Log("Reloaded!");
    }

    private void MekanikTembak()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(10);
            }
        }

    }

    private void MekanikHeadshot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            EnemyHeadshot enemyKepala = hit.collider.GetComponent<EnemyHeadshot>();
            if (enemyKepala != null)
            {
                enemyKepala.HeadshotExecute();
            }
        }
    }



}
