using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float yImpulse;
    [SerializeField] float flapCD;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Sprite[] sprites; 

    private float tilt = 5f;
    private float gravity;
    private int spriteIndex;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gravity = rb.gravityScale;
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * yImpulse;
        }

        Vector3 rotation = transform.eulerAngles;
        rotation.z = rb.velocity.y * tilt;
        transform.eulerAngles = rotation;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }
}
