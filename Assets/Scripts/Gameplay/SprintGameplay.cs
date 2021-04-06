
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
    public const int MAX_SPRINT = 3;
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

    public bool isOver()
    {
        return sprintNumber >= MAX_SPRINT;
    }

    public void advanceToWorkWithInIteration()
    {
        phase = Phase.WorkWithInIteration;
        sprintRenderComponent.hidePlanningAndCommitementSprite();
        int estimationValue = Board.getInstance().toDo.GetComponent<Column>()
            .getGameplayComponent().sum();
        Board.getInstance().toDo.GetComponent<Column>()
            .getGameplayComponent().moveCardsToColumn(ColumnGameplayComponent.ONPROGRESS_TAG);
        
        sprintRenderComponent.setPlanMesh(sprintNumber, estimationValue);
        Iteration.getInstance().getGameplaycomponent().startWorkInIteration();
    }

    public void advanceToSprintPlanning()
    {
        if (!isOver())
        {
            phase = Phase.PlanningAndCommitment;
            sprintRenderComponent.hideSprintRetrospective();
            sprintRenderComponent.showPlanningAndCommitementSprite();
            setSprint(sprintNumber + 1);
        }
    }

    public void advanceToSpringReview()
    {
        sprintRenderComponent.showSprintRetrospective();
        phase = Phase.SpringReviewAndRetrospective;
        int estimationValue = Board.getInstance().onProgress.GetComponent<Column>()
            .getGameplayComponent().sumFinished();
        Board.getInstance().onProgress.GetComponent<Column>()
            .getGameplayComponent().moveCardsToColumn(ColumnGameplayComponent.DONE_TAG);
        sprintRenderComponent.setActualMesh(sprintNumber, estimationValue);
    }

    private void setSprint(int sprintValue)
    {
        sprintNumber = sprintValue;
        sprintRenderComponent.setSprintNumberMesh(sprintNumber);
    }










}
