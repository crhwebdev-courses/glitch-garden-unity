using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] private Defender _defenderPrefab;

    private SpriteRenderer _spriteRenderer;
    private Color _defaultColor;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();        
    }

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogError(name + " has no cost text; add some!");
        }
        else
        {
            costText.text = _defenderPrefab.StarCost.ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(82, 81, 81, 255);
        }

        _spriteRenderer.color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(_defenderPrefab);
    }   
}
