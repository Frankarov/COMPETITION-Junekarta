using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipBagianPlayer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        if (mouseWorldPos.x < transform.position.x)
        {
            FlipX(true);
        }
        else
        {
            FlipX(false);
        }
    }

    void FlipX(bool flip)
    {
        if (flip)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
