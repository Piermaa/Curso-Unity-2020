using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    float horizontalInput;
    // Start is called before the first frame update

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up , rotationSpeed * Time.deltaTime * horizontalInput);
    }
}
