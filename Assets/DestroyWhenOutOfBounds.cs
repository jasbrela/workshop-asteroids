using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenOutOfBounds : MonoBehaviour
{
    void Update()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        
        float tolerance = 1f;
        if (transform.position.y < -bounds.y - tolerance ||
            transform.position.y > bounds.y + tolerance ||
            transform.position.x < -bounds.x - tolerance ||
            transform.position.x > bounds.x + tolerance)
        {
            Destroy(this.gameObject);
        }
    }
}