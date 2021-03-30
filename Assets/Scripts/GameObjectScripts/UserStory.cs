using UnityEngine;
using UnityEngine.Assertions;

/**
 * this class represents the user story game entity
 */
public class UserStory : MonoBehaviour
{
    private UserStoryInputHandler _inputHandler;
    private CardRenderComponent _renderComponent;
    private UserStoryGameplay _userStoryGameplay;
    public const string TAG = "UserStory";
    private void Start()
    {
        Assert.AreEqual(tag, TAG);
        _userStoryGameplay = new UserStoryGameplay();
        _renderComponent = new CardRenderComponent(GetComponent<SpriteRenderer>());
        _inputHandler = new UserStoryInputHandler(GetComponent<Transform>(), _renderComponent, this);
        
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

    public UserStoryGameplay getGameplayComponent()
    {
        return _userStoryGameplay;
    }

}
