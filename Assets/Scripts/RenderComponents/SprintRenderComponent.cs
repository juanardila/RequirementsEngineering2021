using TMPro;
using UnityEngine;

public class SprintRenderComponent
{
    private SpriteRenderer planningAndCommitmentSprite;
    private SpriteRenderer sprintReviewAndRetrospectiveSprite;
    private SpriteRenderer advanceToWorkWithInIterationSprite;
    private SpriteRenderer advanceToPlanningAndCommitementSprite;

    private TextMeshProUGUI sprintNumberMesh;

    private TextMeshProUGUI[] sprintEstimations;

    public SprintRenderComponent(SpriteRenderer planningAndCommitmentSprite,
        SpriteRenderer advanceToWorkWithInIterationSprite,
        SpriteRenderer sprintRetrospective, SpriteRenderer advanceToPlanningSprite,
        TextMeshProUGUI sprintNumberMesh, TextMeshProUGUI[] sprintEstimations)
    {
        this.planningAndCommitmentSprite = planningAndCommitmentSprite;
        this.advanceToWorkWithInIterationSprite = advanceToWorkWithInIterationSprite;
        this.advanceToPlanningAndCommitementSprite = advanceToPlanningSprite;
        this.sprintReviewAndRetrospectiveSprite = sprintRetrospective;
        this.sprintNumberMesh = sprintNumberMesh;
        this.sprintEstimations = sprintEstimations;

    }

    private TextMeshProUGUI getActualMesh(int sprintNo)
    {
        return sprintEstimations[sprintNo * 2 - 1];
    }

    private TextMeshProUGUI getPlanMesh(int sprintNo)
    {
        return sprintEstimations[sprintNo * 2 - 2];
    }

    public void showPlanningAndCommitementSprite()
    {
        planningAndCommitmentSprite.enabled = true;
        advanceToWorkWithInIterationSprite.enabled = true;
    }

    public void hidePlanningAndCommitementSprite()
    {
        planningAndCommitmentSprite.enabled = false;
        advanceToWorkWithInIterationSprite.enabled = false;
    }

    public void showSprintRetrospective()
    {
        sprintReviewAndRetrospectiveSprite.enabled = true;
        advanceToPlanningAndCommitementSprite.enabled = true;
    }
    
    public void hideSprintRetrospective()
    {
        sprintReviewAndRetrospectiveSprite.enabled = false;
        advanceToPlanningAndCommitementSprite.enabled = false;
    }

    public void setSprintNumberMesh(int value)
    {
        sprintNumberMesh.text = value.ToString();
    }

    public void setPlanMesh(int sprintNo, int value)
    {
        getPlanMesh(sprintNo).text = value.ToString();
    }

    public void setActualMesh(int sprintNo, int value)
    {
        getActualMesh(sprintNo).text = value.ToString();
    }
    
}
