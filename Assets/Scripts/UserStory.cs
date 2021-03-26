using UnityEngine;
/**
 * this class represents the user story game entity
 */
public class UserStory : MonoBehaviour
{

    public int id;
    public int points;
    public string text;
    private UserStoryInputHandler _inputHandler;
    
    private void Start()
    {
        _inputHandler = new UserStoryInputHandler(GetComponent<Transform>(), this);
    }

    private void OnMouseDown()
    {
        _inputHandler.onClick();
    }

    private void OnMouseDrag()
    {
        _inputHandler.onDrag();
    }

    private void OnMouseUpAsButton()
    {
        _inputHandler.onRelase();        
    }

}
