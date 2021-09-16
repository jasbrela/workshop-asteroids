using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenOutOfBounds : MonoBehaviour
{
    private Vector3 bounds;
    private void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    void Update()
    {
        float tolerance = 1.5f;
        if (transform.position.y < -bounds.y - tolerance ||
            transform.position.y > bounds.y + tolerance ||
            transform.position.x < -bounds.x - tolerance ||
            transform.position.x > bounds.x + tolerance)
        {
            Destroy(this.gameObject);
        }
    }
}