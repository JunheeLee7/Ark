using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cams : MonoBehaviour
{
    public float zoomSpeed = 1.0f;
    public float targetDist = 0.0f;
    public Vector2 zoomRange = new Vector2(1.0f, 7.0f);

    private void Update()
    {
        targetDist = -Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        targetDist = Mathf.Clamp(targetDist, zoomRange.x, zoomRange.y);


    }
}
