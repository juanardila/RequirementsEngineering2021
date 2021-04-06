using System.Collections.Generic;
using UnityEngine;

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
    private int cardDrawnId;
    private GameObject cardDrawnGameObject;
    public  Turn(IterationRendererComponent iterationRendererComponent, Round round)
    {
        this.iterationRendererComponent = iterationRendererComponent;
        turnState = TurnState.STARTED_TURN;
        selectedStory = null;
        diceResult = 0;
        cardDrawnId = 0;
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
                    Board.getInstance().deleteInstantiatedCard(cardDrawnGameObject);
                    IterationNetworkComponent.sendTurnInfo(selectedStory.id, diceResult, cardDrawnId );
                    round.finishLocalTurn();
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
        if (selectedStory != null)
        {
            selectedStory.setAvailableToWork();
        }
        selectedStory = userStoryGameplayComponent;
        turnState = TurnState.SELECTED_USER_STORY;
        play();
    }

    public UserStoryGameplayComponent getSelectedStory()
    {
        return selectedStory;
    }

    public void rollDices()
    {
        int firstRollValue = Dice.getInstance().
             getFirstDiceGameplayComponent().rollDice();
         int secondRollValue = Dice.getInstance().
             getSecondDiceGameplayComponent().rollDice();
        setDiceResult(firstRollValue + secondRollValue);
        
        //
        cardDrawnId = Board.getInstance().chanceDeck.drawFromDeck();
        ChanceCard cardDrawn = Board.getInstance().chanceDeck.getChanceCard(cardDrawnId);
        cardDrawn.chanceCardGameplayComponent.followInstructions();
        cardDrawnGameObject = Board.getInstance().showCard(cardDrawn);
        //
        this.selectedStory.setPoints(selectedStory.points - diceResult);
        
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

    public void setDrawnCard(GameObject gameObject)
    {
        cardDrawnGameObject = gameObject;
    }

    public int getDrawnCardId()
    {
        return cardDrawnId;
    }
    
    public void setDrawnCardId(int drawnCardId)
    {
        this.cardDrawnId = drawnCardId;
    }

    public void setSelectedUserStory(UserStoryGameplayComponent userStoryGameplayComponent)
    {
        selectedStory = userStoryGameplayComponent;
    }

    public int currentPlayer()
    {
        return playingPlayerIndex;
    }

    public int getDiceResult()
    {
        return diceResult;
    }
}

