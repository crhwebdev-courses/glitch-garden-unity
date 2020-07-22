using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] private int _lives = 5;
    [SerializeField] private int _damage = 1;
    private Text _livesText;
    
    void Start()
    {
        _livesText = GetComponent<Text>();
        UpdateDisplay();
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
