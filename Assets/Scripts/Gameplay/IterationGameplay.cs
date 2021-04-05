using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
public class IterationGameplay
{
    struct IterationFlags
    {
        bool substractOneFromEveryOneThisTurn;
        Player skipsTurn;
        bool everyOneSkipsTurn;
    };
    
    private IterationRendererComponent iterationRendererComponent;
    private Player[] playersList;
    private int day;
    private int currentPlayer;
    private int rollValue;

    public IterationGameplay(IterationRendererComponent iterationRendererComponent)
    {
        this.iterationRendererComponent = iterationRendererComponent;
    }
    
    public void startIteration()
    {
        if (Sprint.getInstance().getGameplayComponent().getSprintNumber() == 1)
        {
            iterationRendererComponent.assignNames(Iteration.getPlayerNames());
            playersList = PhotonNetwork.PlayerList;    
        }
        day = 1;
        currentPlayer = 0;
        iterationRendererComponent.showPlayerIndicator(currentPlayer);
        PlayerGameplay.startDailyWork();
    }
    
    public void nextPlayerWorks()
    {
        iterationRendererComponent.hidePlayerIndicator(currentPlayer);
        if (currentPlayer < playersList.Length)
        {
            currentPlayer++;
            iterationRendererComponent.showPlayerIndicator(currentPlayer);
            PlayerGameplay.startDailyWork();
        }
        else
        {
            currentPlayer = 0;
        }
    }
    
    public int getPlayerIndex()
    {
        return currentPlayer;
    }

    public Player getCurrentPlayer()
    {
        return playersList[currentPlayer];
    }

    public void allowRollDice()
    {
        iterationRendererComponent.showRollButton();
    }

    public void rollDices()
    {
        if (PlayerGameplay.playerHasSelectedStory())
        {
            int firstRollValue = Dice.getInstance().
                getFirstDiceGameplayComponent().rollDice();
            int secondRollValue = Dice.getInstance().
                getSecondDiceGameplayComponent().rollDice();
            setRollValue(firstRollValue + secondRollValue);
            //Draw a card and apply changes
            int cardDrawn = Board.getInstance().chanceDeck.drawCard();
            //Broadcarst Dice and Card Information
            //iterationNetworkComponent.sendTurnInformation(rollValue, cardDrawn, PlayerGameplay.workedOnStory.id);
            
        }
        
    }

    public void setRollValue(int rollValue)
    {
        this.rollValue = rollValue;
        iterationRendererComponent.showRollValue(rollValue);
    }

    public int getRollValue()
    {
        return rollValue;
    }





}
