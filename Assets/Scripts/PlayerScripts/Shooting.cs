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

    public bool canShoot = true;

    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }

    private void Start()
    {
        canShoot = true;
    }

    private void Update()
    {

        aimGunEndPointObject = GameObject.Find("GunEndPointPosition");
        aimGunEndPointTransform = aimGunEndPointObject.transform;

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Debug.Log("Tembak");
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
