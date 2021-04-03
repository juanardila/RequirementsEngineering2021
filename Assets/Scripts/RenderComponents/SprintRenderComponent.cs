using UnityEngine;

public class SprintRenderComponent
{
    private SpriteRenderer planningAndCommitmentSprite;
    private SpriteRenderer springReviewAndRetrospective;
    private SpriteRenderer advanceToWorkWithInIterationSprite;
    private SpriteRenderer advanceToSprintReviewAndRetrospectiveSprite;
    private SpriteRenderer advanceSprint;

    public SprintRenderComponent(SpriteRenderer planningAndCommitmentSprite, SpriteRenderer advanceToWorkWithInIterationSprite)
    {
        this.planningAndCommitmentSprite = planningAndCommitmentSprite;
        this.advanceToWorkWithInIterationSprite = advanceToWorkWithInIterationSprite;
        

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
    

}
