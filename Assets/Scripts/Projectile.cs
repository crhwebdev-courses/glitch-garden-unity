﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
        
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed);        
    }
}
