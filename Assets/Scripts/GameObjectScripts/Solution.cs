
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Solution : MonoBehaviour
{
    public const string TAG = "Solution";
    private SolutionInputHandler _solutionInputHandler;
    private void OnEnable()
    {
        this.tag = TAG;
        this._solutionInputHandler = new SolutionInputHandler(GetComponent<Transform>());
    }

    private void OnMouseDown()
    {
        _solutionInputHandler.onClick();
    }

    private void OnMouseDrag()
    {
        _solutionInputHandler.onDrag();
    }

    private void OnMouseUpAsButton()
    {
        _solutionInputHandler.onRelase();
    }
}
