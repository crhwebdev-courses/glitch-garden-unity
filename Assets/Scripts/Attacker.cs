using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    //[Range(0f, 5f)] [SerializeField] private float _walkSpeed = 1f;
    [SerializeField] private float _damage = 50f;
    private float _currentSpeed = 1f;
    private GameObject _currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _currentSpeed);
        UpdateAnimationState();
    }

    private void OnDestroy()
    {
        LevelController LevelController = FindObjectOfType<LevelController>();

        if(LevelController != null)
        {
            LevelController.AttackerKilled();
        }
        
    }

    private void UpdateAnimationState()
    {
        if (!_currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        _currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        _currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        //Note: we will be using the _damage amount set on attacker
        // instead of in the animation event, but we still need to 
        // take an argument so that the animation script works
        if (!_currentTarget) { return; }
        Health health = _currentTarget.GetComponent<Health>();
        if (health)
        {
            health.TakeDamage(_damage);            
        }
    }

   
}
