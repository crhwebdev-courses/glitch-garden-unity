using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] private float _baseLives = 3f;    
    [SerializeField] private int _damage = 1;

    private float _lives = 5f;
    private Text _livesText;
    
    void Start()
    {
        _lives = _baseLives - PlayerPrefsController.GetDifficulty();
        _livesText = GetComponent<Text>();
        UpdateDisplay();
        Debug.Log("difficulty setting currently is " + PlayerPrefsController.GetDifficulty());
    }       

    private void UpdateDisplay()
    {
        _livesText.text = _lives.ToString();
    }
        
    public void TakeLife()
    {               
        _lives -= _damage;
        UpdateDisplay();
     
        if(_lives <= 0)
        {            
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
