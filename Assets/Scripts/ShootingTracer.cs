using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootingTracer : MonoBehaviour
{
    public Shooting shootingScript;
    public Material weaponTracerMaterial;
    public Sprite gunMuzzle;
    public GameObject pivotDecider;


    private void Start()
    {
        shootingScript.OnShoot += shootingScript_OnShoot;
    }

    private void shootingScript_OnShoot(object sender, Shooting.OnShootEventArgs e)
    {
        CreateWeaponTracer(e.gunEndPointPosition, e.shootPosition);
        CreateGunMuzzle(e.gunEndPointPosition);
    }

    private void CreateWeaponTracer(Vector3 fromPosition, Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - fromPosition).normalized;
        float eulerZ = UtilsClass.GetAngleFromVectorFloat(direction) - 90;
        float distance = Vector3.Distance(fromPosition, targetPosition);
        Vector3 tracerSpawnPosition = fromPosition + direction * distance * .5f;
        Material tmpWeaponTracerMaterial = new Material(weaponTracerMaterial);
        tmpWeaponTracerMaterial.SetTextureScale("_MainTex", new Vector2(1f, distance / 256f));
        World_Mesh worldMesh = World_Mesh.Create(tracerSpawnPosition, eulerZ, .5f, distance, weaponTracerMaterial, null, 50000);//6 dan 1000

        float timer = .1f;
        FunctionUpdater.Create(() =>
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                worldMesh.DestroySelf();
                return true;
            }
            return false;
        });

    }

    private void CreateGunMuzzle(Vector3 spawnPosition)
    {
        World_Sprite worldSprite = World_Sprite.Create(spawnPosition, gunMuzzle);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - pivotDecider.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        worldSprite.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        worldSprite.transform.Rotate(0f, 0f, angle);

        FunctionTimer.Create(worldSprite.DestroySelf, .1f);
    }

}
