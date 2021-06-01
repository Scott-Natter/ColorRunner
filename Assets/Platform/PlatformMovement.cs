using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    private float width = -10;
    public float scrollSpeed = -2f;

    void Start()
    {
        rb.velocity = new Vector2(scrollSpeed, 0);
    }

    void Update()
    {
        rb.velocity = new Vector2(scrollSpeed, 0);
        if(transform.position.x < -43f)
        {
            Vector2 resetPosition = new Vector2(80.0f, 0);
            transform.position = ((Vector2)transform.position + resetPosition);
        }
    }
}
