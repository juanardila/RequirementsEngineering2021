using System;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;


/**
 * this class represents the user story game entity
 */
public class UserStory : MonoBehaviour
{
    private UserStoryInputHandler _inputHandler;
    private UserStoryRendererComponent _renderComponent;
    private UserStoryGameplayComponent _userStoryGameplayComponent;
    private UserStoryInteractionComponent _userStoryInteractionComponent;
    private UserStoryNetworkingComponent _userStoryNetworkingComponent;

    public const string TAG = "UserStory";
    public TextMeshProUGUI idMesh;
    public TextMeshProUGUI titleMesh;
    public TextMeshProUGUI pointsMesh;
    public Sprite workInStorySprite;
    public Sprite workingInStorySprite;
    public Sprite workingDisabledSprite;

    private void OnEnable()
    {
        Assert.AreEqual(tag, TAG);
        _userStoryNetworkingComponent = new UserStoryNetworkingComponent();
        _userStoryInteractionComponent = new UserStoryInteractionComponent();
        _renderComponent = new UserStoryRendererComponent(GetComponent<SpriteRenderer>(), pointsMesh,
            workInStorySprite, workingInStorySprite, workingDisabledSprite);
        _userStoryGameplayComponent = new UserStoryGameplayComponent(_userStoryInteractionComponent,
            GetComponent<Transform>(), _userStoryNetworkingComponent, _renderComponent);
        _inputHandler = new UserStoryInputHandler(GetComponent<Transform>(),
            _renderComponent, _userStoryGameplayComponent, _userStoryInteractionComponent);
    }
    /**
     * Helper function that fills the values of the user story after
     * initialization with Instantiate
     */
    public void initializeGameplay(int id, string title, int points)
    {
        this.idMesh.text = id.ToString();
        this.titleMesh.text = title;
        this.pointsMesh.text = points.ToString();
        _userStoryGameplayComponent.initializeRunTimeAttributes(id, title, points, this.pointsMesh);
        Board.getInstance().getColumn(ColumnGameplayComponent.BACLOG_TAG)
            .add(_userStoryGameplayComponent, GetComponent<Transform>());
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

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag(Solution.TAG) && 
            _userStoryGameplayComponent.haveProblems())
        {
            int userStoryId = _userStoryGameplayComponent.id;
            int  solutionId = other.gameObject
                .GetComponent<Card>().getChanceCardGameplayComponent().getId();
            
            //Send deleted one problem with userstory id solution id
            
            Destroy(_userStoryGameplayComponent.deleteProblem());
            Destroy(other.gameObject);
        }
    }
}
