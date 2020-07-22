using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{    
    [SerializeField] private float _minSpawnDelay = 1f;
    [SerializeField] private float _maxSpawnDelay = 5f;
    [SerializeField] private Attacker[] _attackerPrefabs;

    private bool _spawn = true;

    private IEnumerator Start()
    {
        float waitTime;
        while (_spawn)
        {            
            waitTime = UnityEngine.Random.Range(_minSpawnDelay, _maxSpawnDelay);
            yield return new WaitForSeconds(waitTime);            
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        _spawn = false;
    }
    private void SpawnAttacker()
    {
        var attackerIndex = UnityEngine.Random.Range(0, _attackerPrefabs.Length);
        Spawn(_attackerPrefabs[attackerIndex]);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(
                    attacker,
                    transform.position,
                    transform.rotation) as Attacker;

        newAttacker.transform.parent = transform;
    }   
}
