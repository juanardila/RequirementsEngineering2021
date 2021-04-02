using System;
using System.Diagnostics;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;
using UnityEngine.UIElements;
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
    public TextMeshProUGUI id;
    public TextMeshProUGUI title;
    public TextMeshProUGUI points;

    private void OnEnable()
    {
        Assert.AreEqual(tag, TAG);
        _userStoryNetworkingComponent = new UserStoryNetworkingComponent(GetComponent<PhotonView>());
        _userStoryInteractionComponent = new UserStoryInteractionComponent();
        _userStoryGameplayComponent = new UserStoryGameplayComponent(_userStoryInteractionComponent, GetComponent<Transform>(), _userStoryNetworkingComponent);
        _renderComponent = new CardRenderComponent(GetComponent<SpriteRenderer>());
        _inputHandler = new UserStoryInputHandler(GetComponent<Transform>(),
            _renderComponent, _userStoryGameplayComponent, _userStoryInteractionComponent);
    }
    /**
     * Helper function that fills the values of the user story after
     * initialization with Instantiate
     */
    public void initializeGameplay(string id, string title, string points)
    {
        this.id.text = id;
        this.title.text = title;
        this.points.text = points;
        _userStoryGameplayComponent.initializeRunTimeAttributes(1, title, 30, this.points);
        Board.getInstance().getColumn(ColumnGameplayComponent.BACLOG_TAG)
            .add(_userStoryGameplayComponent, GetComponent<Transform>());
    }
    
    //Networking Remote Proccedure Calls.... for user stories
    [PunRPC]
    public void _moveUserStory(int userStoryId,string prevColumn, string newColumn )
    {
        UserStoryGameplayComponent.moveToColumn(userStoryId, prevColumn, newColumn );
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
