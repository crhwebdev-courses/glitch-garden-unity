using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int _stars = 100;
    private Text _starText;
    
    void Start()
    {
        _starText = GetComponent<Text>();
        UpdateDisplay();
    }       

    private void UpdateDisplay()
    {
        _starText.text = _stars.ToString();
    }

    public void AddStars(int amount)
    {
        _stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        
        if(_stars >= amount) 
        {
            _stars -= amount;
            UpdateDisplay();
        }        
    }
}
