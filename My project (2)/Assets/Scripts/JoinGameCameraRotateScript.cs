using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinGameCameraRotateScript : MonoBehaviour
{
    public float x = 0;
    public float y = 0;
    public float z = 0;

    void Update()
    { 
        x += 0.1f;
        y += 0.1f;
        z += 0.1f;
        this.transform.localRotation = Quaternion.Euler(x, y, z);
    }
}
