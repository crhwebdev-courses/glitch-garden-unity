using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int _splashDelay = 4;

    private int _splashScreen = 0;
    private int _startScreen = 1;
    private int _currentSceneIndex;
    
    private void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(_currentSceneIndex == _splashScreen)
        {
            StartCoroutine(LoadScreenAfterDelay(_startScreen, _splashDelay));
        }
        
    }
    
    private IEnumerator LoadScreenAfterDelay(int screen, int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(screen);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }
}
