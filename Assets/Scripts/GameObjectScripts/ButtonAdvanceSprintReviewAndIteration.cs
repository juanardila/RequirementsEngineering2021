
using System;
using UnityEngine;

public class ButtonAdvanceSprintReviewAndIteration : MonoBehaviour
{
    private IterationInputHandler _iterationInputHandler;

    private void Start()
    {
        _iterationInputHandler = new IterationInputHandler();
    }

    private void OnMouseDown()
    {   
        _iterationInputHandler.startDayOrAdvancePhase();
    }
}
