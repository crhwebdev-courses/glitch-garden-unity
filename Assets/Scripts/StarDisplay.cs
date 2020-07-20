using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int _stars = 100;
    [SerializeField] private int _starGenerationAmount = 3;
    private Text _starText;
    
    public int Stars
    { 
        get
        {
            return _stars;
        }
    }

    void Start()
    {
        _starText = GetComponent<Text>();
        UpdateDisplay();
    }       

    private void UpdateDisplay()
    {
        _starText.text = _stars.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return _stars >= amount;
    }
    
    public void AddStars(int amount)
    {
        //Note: we have to take an amount because the animation script event
        //is stuck with passing a value.  We will use the vaule set on StarDisplay
        // instead
        _stars += _starGenerationAmount;
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
