using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in seconds")]
    [SerializeField] private float _levelTime = 10;
    private bool _triggeredLevelFinished = false;
    
    void Update()
    {
        if (_triggeredLevelFinished){ return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / _levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= _levelTime);
        if (timerFinished)
        {
            _triggeredLevelFinished = true;
            FindObjectOfType<LevelController>().LevelTimerFinished();
            
        }
    }
}
