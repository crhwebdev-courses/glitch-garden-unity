﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int _starCost = 100;

    public int StarCost
    {
        get
        {
            return _starCost;
        }
    }

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }
}
