using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{    
    private LivesDisplay _lives;    

    private void Start()
    { 
        _lives = FindObjectOfType<LivesDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<Attacker>())
        {            
            _lives.TakeLife();
            Destroy(otherCollider.gameObject, 1f);           
        }        
    }
}
