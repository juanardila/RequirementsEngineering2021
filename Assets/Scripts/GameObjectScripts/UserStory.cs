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
    public TextMeshProUGUI id;
    public TextMeshProUGUI title;
    public TextMeshProUGUI points;
    public Sprite workInStorySprite;
    public Sprite workingInStorySprite;
    public Sprite workingDisabledSprite;

    private void OnEnable()
    {
        Assert.AreEqual(tag, TAG);
        _userStoryNetworkingComponent = new UserStoryNetworkingComponent();
        _userStoryInteractionComponent = new UserStoryInteractionComponent();
        _renderComponent = new UserStoryRendererComponent(GetComponent<SpriteRenderer>(), points,
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
        this.id.text = id.ToString();
        this.title.text = title;
        this.points.text = points.ToString();
        _userStoryGameplayComponent.initializeRunTimeAttributes(id, title, points, this.points);
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
    
}
