using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBehaviour : MonoBehaviour
{
    public float rotateSpeed = 40f;

    void Update()
    {
        //Make sure you are using the right parameters here
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}