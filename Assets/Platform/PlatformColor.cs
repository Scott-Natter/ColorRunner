using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColor : Colors
{
    public GameColor platformColor;
    BoxCollider2D collider;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        Debug.Log(collider);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player")
        {
            if(other.transform.GetComponent<PlayerColor>().characterColor != platformColor)
                collider.enabled = false;
            else
                collider.enabled = true;

        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.transform.tag == "Player")
        {
            if(other.transform.GetComponent<PlayerColor>().characterColor != platformColor)
                collider.enabled = false;
        }
    }
}
