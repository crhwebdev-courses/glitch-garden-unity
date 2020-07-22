using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in seconds")]
    [SerializeField] private float _levelTime = 10;
    
    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / _levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= _levelTime);
        if (timerFinished)
        {
            Debug.Log("level timer expired!");
        }
    }
}
