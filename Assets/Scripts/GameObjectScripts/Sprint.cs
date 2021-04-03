using Photon.Pun;
using TMPro;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    public TextMeshProUGUI sprintNumber;
    public SpriteRenderer planningAndCommitmentSprite;
    public SpriteRenderer advanteToWorkWithInIteration;
    
    private SprintGameplay _sprintGameplay;
    private SprintRenderComponent _sprintRenderComponent;

    private static Sprint _instance;

    public static Sprint getInstance()
    {
        return _instance;
    }

    //Singleton pattern
    //https://gamedev.stackexchange.com/questions/116009/in-unity-how-do-i-correctly-implement-the-singleton-pattern
    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _sprintRenderComponent = new SprintRenderComponent(planningAndCommitmentSprite, advanteToWorkWithInIteration);
            _sprintGameplay = new SprintGameplay(_sprintRenderComponent);
            _instance = this;
        }
    }

    private Sprint(){}

    public SprintGameplay getGameplayComponent()
    {
        return _sprintGameplay;
    }



    [PunRPC]
    private void _advanceToWorkWithInIteration()
    {
        _sprintGameplay.advanceToWorkWithInIteration();
    }
    
    
    
}
