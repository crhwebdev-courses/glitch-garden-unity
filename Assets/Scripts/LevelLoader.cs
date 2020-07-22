using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int _splashDelay = 4;

    private int _splashScreen = 0;
    private int _startScreen = 1;
    private string _gameOverScreen = "Game Over Screen";
    private int _currentSceneIndex;
    
    private void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(_currentSceneIndex == _splashScreen)
        {
            StartCoroutine(LoadScreenAfterDelay(_startScreen, _splashDelay));
        }
        
    }
    
    public void LoadGameOverScene()
    {
        //Note: calling start screen for now
        StartCoroutine(LoadScreenAfterDelay(_gameOverScreen, 2));
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(_currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(_startScreen);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadScreenAfterDelay(int screen, int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(screen);
    }

    private IEnumerator LoadScreenAfterDelay(string screen, int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(screen);
    }


}
