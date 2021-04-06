using UnityEngine;

public class ButtonAdvanceSprintPlanning : MonoBehaviour
{
    private SprintInputHandler _sprintInputHandler; 
    private void Start()
    {
        _sprintInputHandler = new SprintInputHandler();
        
    }

    private void OnMouseDown()
    {
        _sprintInputHandler.onAdvanceToSprintPlanningClick();
    }
}