using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    Transform parent;
    float startDistX;
    private void Awake()
    {
        parent = transform.parent;
        startDistX = transform.position.x;
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if(x > 0)
        {
            var pos = parent.position;
            pos.x += startDistX;
            pos.y = transform.position.y;
            transform.position = pos;
        }
        if (x < 0)
        {
            var pos = parent.position;
            pos.x -= startDistX;
            pos.y = transform.position.y;
            transform.position = pos;
        }

    }
}
