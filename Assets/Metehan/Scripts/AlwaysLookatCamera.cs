using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysLookatCamera : MonoBehaviour
{
    private Camera maincamera;
    private void Awake()
    {
        maincamera = Camera.main;
    }

    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(maincamera.transform);
    }
}
