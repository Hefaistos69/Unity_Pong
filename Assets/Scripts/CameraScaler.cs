using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    private float defaultWidth;

    void Start()
    {
        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;
    }
}
