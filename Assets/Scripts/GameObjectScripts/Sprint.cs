using Photon.Pun;
using TMPro;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    public TextMeshProUGUI SprintNumber;
    public SpriteRenderer PlanningAndCommitmentSprite;
    public SpriteRenderer AdvanteToWorkWithInIteration;
    public SpriteRenderer AdvanceToSprintPlanning;
    public SpriteRenderer SprintRetrospective;
    public TextMeshProUGUI SprintNumberMesh;
    
    public TextMeshProUGUI sprint1Plan;
    public TextMeshProUGUI sprint1Actual;
    
    public TextMeshProUGUI sprint2Plan;
    public TextMeshProUGUI sprint2Actual;
    
    public TextMeshProUGUI sprint3Plan;
    public TextMeshProUGUI sprint3Actual;
    
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
            TextMeshProUGUI[] sprintsEstimations = new[]
                {sprint1Plan, sprint1Actual, sprint2Plan, sprint2Actual, sprint3Plan, sprint3Actual};
            _sprintRenderComponent = new SprintRenderComponent(PlanningAndCommitmentSprite,
                AdvanteToWorkWithInIteration, SprintRetrospective, AdvanceToSprintPlanning,
                SprintNumberMesh, sprintsEstimations);
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
