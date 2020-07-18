using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{    
    [SerializeField] private float _minSpawnDelay = 1f;
    [SerializeField] private float _maxSpawnDelay = 5f;
    [SerializeField] private Attacker _attackerPrefab;

    private bool _spawn = true;

    private IEnumerator Start()
    {
        float waitTime;
        while (_spawn)
        {            
            waitTime = UnityEngine.Random.Range(_minSpawnDelay, _maxSpawnDelay);
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Spawning an enemy");
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Instantiate(_attackerPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
