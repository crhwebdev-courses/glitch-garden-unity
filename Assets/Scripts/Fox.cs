using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {        
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Gravestone>())
        {
            Jump();
        }
        else if (otherObject.GetComponent<Defender>())
        {            
            GetComponent<Attacker>().Attack(otherObject);            
        }
    }

    private void Jump()
    {
        GetComponent<Animator>().SetTrigger("jumpTrigger");
    }
}
