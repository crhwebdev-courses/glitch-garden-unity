using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile, gun;
    private AttackerSpawner _myLaneSpawner;
    private AttackerSpawner[] _spawners;
    private Animator _animator;

    private void Start()
    {        
        SetLaneSpawner();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            _animator.SetBool("isAttacking", true);
        }
        else
        {   
            _animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        _spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in _spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                _myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        // if my lane spawner child count less than or equal to 0
        // return false
        if(_myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }

        
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
