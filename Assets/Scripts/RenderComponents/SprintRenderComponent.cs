using UnityEngine;

public class SprintRenderComponent
{
    private SpriteRenderer planningAndCommitmentSprite;
    private SpriteRenderer sprintReviewAndRetrospectiveSprite;
    private SpriteRenderer advanceToWorkWithInIterationSprite;
    private SpriteRenderer advanceToPlanningAndCommitementSprite;



    public SprintRenderComponent(SpriteRenderer planningAndCommitmentSprite,
        SpriteRenderer advanceToWorkWithInIterationSprite,
        SpriteRenderer sprintRetrospective, SpriteRenderer advanceToPlanningSprite )
    {
        this.planningAndCommitmentSprite = planningAndCommitmentSprite;
        this.advanceToWorkWithInIterationSprite = advanceToWorkWithInIterationSprite;
        this.advanceToPlanningAndCommitementSprite = advanceToPlanningSprite;
        this.sprintReviewAndRetrospectiveSprite = sprintRetrospective;

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
    

}
