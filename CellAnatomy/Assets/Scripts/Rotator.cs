using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private bool isRotating = false;

    public void StartRotating()
    {
        isRotating = true;
    }

    public void StopRotating()
    {
        isRotating = false;
    }

    private void Update()
    {
        if (isRotating)
            transform.Rotate(Vector3.up, 20 * Time.deltaTime);
    }
}
