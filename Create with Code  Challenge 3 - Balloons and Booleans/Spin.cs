using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    float rotateSpeed = 60;
    float translateSpeed = 10;
    void Update()
    {
        this.transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.up);
        this.transform.localPosition+=Vector3.left*translateSpeed*Time.deltaTime;
    }
}
