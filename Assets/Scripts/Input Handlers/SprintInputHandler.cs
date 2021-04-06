using Photon.Pun;

class SprintInputHandler
{
    private Sprint sprint;
    private SprintNetworkComponent sprintNetworkComponent;
    
    public SprintInputHandler()
    {
        sprint = Sprint.getInstance();
        sprintNetworkComponent = new SprintNetworkComponent();
    }

    public void onAdvanceToWorkWithInIterationClick()
    {
        if (sprint.getGameplayComponent().getPhase() == SprintGameplay.Phase.PlanningAndCommitment)
        {
            sprint.getGameplayComponent().advanceToWorkWithInIteration();
            sprintNetworkComponent.sendAdvanceToWorkInIteration();
        }
    }
    
    public void onAdvanceToSprintPlanningClick()
    {
        if (sprint.getGameplayComponent().getPhase() == SprintGameplay.Phase.SpringReviewAndRetrospective)
        {
            sprint.getGameplayComponent().advanceToSprintPlanning();
        }
    }

   
}