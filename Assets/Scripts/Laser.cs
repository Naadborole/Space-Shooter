﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Laser : MonoBehaviour
{
    [SerializeField]
    private float laser_speed=6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*laser_speed*Time.deltaTime);
        if (transform.position.y > 6.2)
        {
            Destroy(this.gameObject);
        }
    }
}