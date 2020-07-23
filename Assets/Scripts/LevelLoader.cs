using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int _splashDelay = 4;

    private int _splashScreen = 0;
    private int _startScreen = 1;
    private string _levelOne = "Level 1";
    private string _gameOverScreen = "Game Over Screen";
    private int _currentSceneIndex;
    private string _optionsScreen = "Options Screen";

    private void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(_currentSceneIndex == _splashScreen)
        {
            StartCoroutine(LoadScreenAfterDelay(_startScreen, _splashDelay));
        }
        
    }
    
    public void LoadNextScene()
    {
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    public void LoadPreviousScene()
    {
        if(_currentSceneIndex > 0)
        {
            SceneManager.LoadScene(_currentSceneIndex - 1);
        }        
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(_levelOne); 
    }

    public void LoadGameOverScene()
    {
        //Note: calling start screen for now
        StartCoroutine(LoadScreenAfterDelay(_gameOverScreen, 2));
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(_currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(_startScreen);
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene(_optionsScreen);
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
