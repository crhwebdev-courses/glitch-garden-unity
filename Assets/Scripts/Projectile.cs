using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _damage = 100f;
    [SerializeField] private float _speed = 5f;
        
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed);        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        
        var health = target.GetComponent<Health>();
        var attacker = target.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}

