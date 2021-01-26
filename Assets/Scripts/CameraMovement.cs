using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float smoothTimeY = 0.2f;
    public float smoothTimeX = 0.2f;
    public Transform targetTransform;
    
    void Awake()
    {
        if (targetTransform == null)
            targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Vector3 target = targetTransform.position - transform.position;
        target.x *= smoothTimeX;
        target.y *= smoothTimeY;
        target.z = 0;

        transform.Translate(target * Time.deltaTime);
    }
}
