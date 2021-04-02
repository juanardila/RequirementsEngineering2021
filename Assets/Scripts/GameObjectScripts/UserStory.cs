using System.Diagnostics;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;
using Debug = UnityEngine.Debug;

/**
 * this class represents the user story game entity
 */
public class UserStory : MonoBehaviour
{
    private UserStoryInputHandler _inputHandler;
    private CardRenderComponent _renderComponent;
    private UserStoryGameplayComponent _userStoryGameplayComponent;
    private UserStoryInteractionComponent _userStoryInteractionComponent;
    private UserStoryNetworkingComponent _userStoryNetworkingComponent;
    public const string TAG = "UserStory";
    
    private void Start()
    {
        Assert.AreEqual(tag, TAG);
        _userStoryNetworkingComponent = new UserStoryNetworkingComponent(GetComponent<PhotonView>());
        _userStoryInteractionComponent = new UserStoryInteractionComponent();
        _userStoryGameplayComponent = new UserStoryGameplayComponent(_userStoryInteractionComponent, GetComponent<Transform>(), _userStoryNetworkingComponent);
        _renderComponent = new CardRenderComponent(GetComponent<SpriteRenderer>());
        _inputHandler = new UserStoryInputHandler(GetComponent<Transform>(),
            _renderComponent, _userStoryGameplayComponent, _userStoryInteractionComponent);
    }
    
    //Networking Remote Proccedure Calls.... for user stories
    [PunRPC]
    public void _moveUserStory(int userStoryId, string column)
    {
        UserStoryGameplayComponent.moveToColumn(userStoryId, column);
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
