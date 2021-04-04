﻿using UnityEngine;

public class ButtonRollDices : MonoBehaviour
{
    private IterationInputHandler _iterationInputHandler; 
    private void Start()
    {
        _iterationInputHandler = new IterationInputHandler();
        
    }

    private void OnMouseDown()
    {
        _iterationInputHandler.rollDices();
    }
}