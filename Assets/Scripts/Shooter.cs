using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile, gun;
    
    private AttackerSpawner _myLaneSpawner;
    private AttackerSpawner[] _spawners;
    private Animator _animator;

    private GameObject _projectileParent;
    private const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        CreateProjectileParent();
        SetLaneSpawner();
        _animator = GetComponent<Animator>();
    }

    private void CreateProjectileParent()
    {
        _projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!_projectileParent)
        {
            _projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
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

        var newProjectile = Instantiate(projectile, gun.transform.position, transform.rotation);
        newProjectile.transform.parent = _projectileParent.transform;
    }
}
