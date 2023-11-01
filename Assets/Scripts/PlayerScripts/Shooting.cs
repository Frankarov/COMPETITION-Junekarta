using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class Shooting : MonoBehaviour
{

    public event EventHandler<OnShootEventArgs> OnShoot;

    public Transform aimTransform;
    private Transform aimGunEndPointTransform;
    private GameObject aimGunEndPointObject;
    private PlayerMovement playerMovementScript;

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
    }

    private void Update()
    {
        // ... (existing code)

        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine(ReloadProcess(2f)); // Trigger reload for 2 seconds
        }

        if (Input.GetMouseButtonDown(0) && canShoot && bulletCount > 0 && !isReloading)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Debug.Log("Tembak");
        aimGunEndPointObject = GameObject.Find("GunEndPointPosition");
        aimGunEndPointTransform = aimGunEndPointObject.transform;
        bulletCount--;

        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        OnShoot?.Invoke(this, new OnShootEventArgs
        {
            gunEndPointPosition = aimGunEndPointTransform.position,
            shootPosition = mousePosition,
        });

        UtilsClass.ShakeCamera(0.05f, 0.15f);
        MekanikTembak();
        MekanikHeadshot();
    }

    private IEnumerator ReloadProcess(float reloadTime)
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        bulletCount = 17;

        isReloading = false;
        Debug.Log("Reloaded!");
    }

    private void MekanikTembak()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
            EnemyHeadshot enemyKepala = hit.collider.GetComponent<EnemyHeadshot>();
            if (enemy != null)
            {
                Debug.Log("Enemy found!");
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
                Debug.Log("EnemyKepala found");
                enemyKepala.HeadshotExecute();
            }
        }
    }



}
