using UnityEngine;

public class ButtonAdvanceWorkWithInIteration : MonoBehaviour
{
    private SprintInputHandler _sprintInputHandler; 
    private void Start()
    {
        _sprintInputHandler = new SprintInputHandler();
        
    }

    private void OnMouseDown()
    {
        _sprintInputHandler.onAdvanceToWorkWithInIterationClick();
    }
}
