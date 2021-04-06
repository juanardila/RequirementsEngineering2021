
using UnityEngine;

public class SprintGameplay
{
    public enum Phase
    {
        PlanningAndCommitment,
        WorkWithInIteration,
        SpringReviewAndRetrospective
    }
    
    private int sprintNumber;
    private Phase phase;
    private SprintRenderComponent sprintRenderComponent;
    
    public SprintGameplay(SprintRenderComponent sprintRenderComponent)
    {
        this.sprintNumber = 1;
        this.phase = Phase.PlanningAndCommitment;
        this.sprintRenderComponent = sprintRenderComponent;
        sprintRenderComponent.showPlanningAndCommitementSprite();
        sprintRenderComponent.hideSprintRetrospective();
    }

    public Phase getPhase()
    {
        return phase;
    }
    
    public int getSprintNumber()
    {
        return sprintNumber;
    }

    public void advanceToWorkWithInIteration()
    {
        phase = Phase.WorkWithInIteration;
        sprintRenderComponent.hidePlanningAndCommitementSprite();
        Board.getInstance().toDo.GetComponent<Column>()
            .getGameplayComponent().moveCardsToColumn(ColumnGameplayComponent.ONPROGRESS_TAG);
        Iteration.getInstance().getGameplaycomponent().startWorkInIteration();
    }

    public void advanceToSpringReview()
    {
        sprintRenderComponent.showSprintRetrospective();
        phase = Phase.SpringReviewAndRetrospective;
        Board.getInstance().onProgress.GetComponent<Column>()
            .getGameplayComponent().moveCardsToColumn(ColumnGameplayComponent.DONE_TAG);
    }

    private void setSprint(int sprintValue)
    {
        
    }

    
    

    
    
    
    
    
}
