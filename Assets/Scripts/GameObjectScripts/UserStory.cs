using UnityEngine;
using UnityEngine.Assertions;

/**
 * this class represents the user story game entity
 */
public class UserStory : MonoBehaviour
{
    private UserStoryInputHandler _inputHandler;
    private CardRenderComponent _renderComponent;
    private UserStoryGameplayComponent _userStoryGameplayComponent;
    private UserStoryInteractionComponent _userStoryInteractionComponent;
    public const string TAG = "UserStory";
    
    private void Start()
    {
        Assert.AreEqual(tag, TAG);
        _userStoryInteractionComponent = new UserStoryInteractionComponent();
        _userStoryGameplayComponent = new UserStoryGameplayComponent(_userStoryInteractionComponent, GetComponent<Transform>());
        _renderComponent = new CardRenderComponent(GetComponent<SpriteRenderer>());
        _inputHandler = new UserStoryInputHandler(GetComponent<Transform>(),
            _renderComponent, _userStoryGameplayComponent, _userStoryInteractionComponent);
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

    public UserStoryGameplayComponent getGameplayComponent()
    {
        return _userStoryGameplayComponent;
    }    
    public UserStoryInteractionComponent getInteractionComponent()
    {
        return _userStoryInteractionComponent;
    }

}
