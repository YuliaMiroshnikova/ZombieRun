using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    public Vector3 rotation = new Vector3(0, 0, 90); // колесики
    public float rotationSpeed = 10.0f;
    public GameObject[] wheels;
    
    
    
    private void Update()
    {
        float v = Input.GetAxis("Vertical");
        
        if (v != 0)
        {foreach (var el in wheels)
            {
                el.transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
            }
        }
        return;
        
    }
}
