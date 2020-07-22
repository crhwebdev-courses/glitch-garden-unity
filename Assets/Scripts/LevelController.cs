using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject _winLabel;
    private int _numberOfAttackers = 0;
    private bool _levelTimerFinished = false;
    private float _waitToLoad = 4f;

    private void Start()
    {
        _winLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        _numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        _numberOfAttackers--;

        if(_numberOfAttackers <= 0 && _levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {                
        _winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(_waitToLoad);
        GetComponent<LevelLoader>().LoadNextScene();
    }

    public void LevelTimerFinished()
    {
        _levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {        
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
