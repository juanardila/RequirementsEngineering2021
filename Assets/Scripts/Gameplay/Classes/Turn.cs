using System.Collections.Generic;

public class Turn
{
    enum TurnState
    {
        STARTED_TURN,
        SELECTED_USER_STORY,
        ROLLED_DICES,
        FINISHED_TURN
    }

    private TurnState turnState;
    private IterationRendererComponent iterationRendererComponent;
    private Round round;
    private int playingPlayerIndex;
    private UserStoryGameplayComponent selectedStory;
    private int diceResult;
    private int cardDrawn;
    public  Turn(IterationRendererComponent iterationRendererComponent, Round round)
    {
        this.iterationRendererComponent = iterationRendererComponent;
        turnState = TurnState.STARTED_TURN;
        selectedStory = null;
        diceResult = 0;
        cardDrawn = 0;
        this.round = round;
    }

    public void play(int playerIndex = 0)
    {
        if (round.localPlayerIsWorking())
        {
            switch (turnState)
            {
                case TurnState.STARTED_TURN:
                    iterationRendererComponent.showPlayerIndicator(playerIndex);
                    showAvailableUserStories();
                    break;
                case TurnState.SELECTED_USER_STORY:
                    iterationRendererComponent.showRollButton();
                    break;
                case TurnState.ROLLED_DICES:
                    iterationRendererComponent.hideRollButton();
                    iterationRendererComponent.showFinishTurn();
                    //Iteration network component
                    break;
                case TurnState.FINISHED_TURN:
                    iterationRendererComponent.hideFinishTurn();
                    iterationRendererComponent.hidePlayerIndicator(playerIndex);
                    hideAvailableUserStories();
                    round.finishLocalTurn();
                    //iteration network component
                    break;
            }
        }
        else
        {
            iterationRendererComponent.showPlayerIndicator(playerIndex);
        }
    }

    private void resetState()
    {
        turnState = TurnState.ROLLED_DICES;
    }
    
    private static void showAvailableUserStories()
    {
        Iteration.getInstance().rollButton.enabled = true;
            LinkedList<StoryNode> storiesInProgress = Board.getInstance().onProgress.GetComponent<Column>()
                .getGameplayComponent().getStories();
            foreach (StoryNode storyNode in storiesInProgress)
            {
                storyNode.userStoryGameplayComponent.setAvailableToWork();
            }
    }
    
    private static void hideAvailableUserStories()
    {
        LinkedList<StoryNode> storiesInProgress = Board.getInstance().onProgress.GetComponent<Column>()
            .getGameplayComponent().getStories();
        foreach (StoryNode storyNode in storiesInProgress)
        {
            storyNode.userStoryGameplayComponent.setUnAvailableToWork();
        }
    }

    public void workInThisStory(UserStoryGameplayComponent userStoryGameplayComponent)
    {
        selectedStory = userStoryGameplayComponent;
        turnState = TurnState.SELECTED_USER_STORY;
        play();
    }

    public void rollDices()
    {
        int firstRollValue = Dice.getInstance().
             getFirstDiceGameplayComponent().rollDice();
         int secondRollValue = Dice.getInstance().
             getSecondDiceGameplayComponent().rollDice();
        setDiceResult(firstRollValue + secondRollValue);
        cardDrawn = Board.getInstance().chanceDeck.drawCard();
        turnState = TurnState.ROLLED_DICES;
        play();
    }

    public void finishTurn()
    {
        turnState = TurnState.FINISHED_TURN;
        play();
    }

    public void setDiceResult(int newValue)
    {
        diceResult = newValue;
        iterationRendererComponent.showRollValue(diceResult);
    }

    public void addToDiceResult(int add)
    {
        setDiceResult(diceResult + add);
    }
    
    
}

