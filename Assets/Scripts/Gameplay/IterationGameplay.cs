using System.Linq;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
public class IterationGameplayComponent
{
    enum IterationState
    {
        WORKING,
        SOLVING_PROBLEMS
    }

    private IterationRendererComponent iterationRendererComponent;
    private int day;
    private Round round;
    public const int FIRST_DAY = 1;
    public const int MAX_DAY = 3;
    private IterationState iterationState = IterationState.WORKING;
    public static string[] getPlayerNames()
    {
        string[] names = new string[PhotonNetwork.PlayerList.Length];
        int index = 0;
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            names[index++] = player.NickName;
        }

        return names;
    }

    public IterationGameplayComponent(IterationRendererComponent iterationRendererComponent)
    {
        this.iterationRendererComponent = iterationRendererComponent;
        setDay(FIRST_DAY);
    }
    
    public void startWorkInIteration()
    {
        iterationRendererComponent.assignNames(getPlayerNames());
        round = new Round(PhotonNetwork.PlayerList.ToArray(), this,
            iterationRendererComponent);
        round.start();
    }
    
    

    public void setDay(int dayValue)
    {
        day = dayValue;
        iterationRendererComponent.setDayMesh(dayValue);
    }

    public Round getRound()
    {
        return round;
    }

    public void endIteration()
    {
        if (!isOver())
        {
            setDay(day + 1);
            round = new Round(PhotonNetwork.PlayerList.ToArray(), this,
                iterationRendererComponent);
            round.start();
        }
        else
        {
            Sprint.getInstance().getGameplayComponent().advanceToSpringReview();
        }
        iterationRendererComponent.hideStartNextDayOrPhaseButton();
        
    }

    public bool isOver()
    {
        return day >= MAX_DAY;
    }


    // public IterationGameplay(IterationRendererComponent iterationRendererComponent)
    // {
    //     this.iterationRendererComponent = iterationRendererComponent;
    // }
    //
    // public void start()
    // {
    //     if (Sprint.getInstance().getGameplayComponent()
    //         .getSprintNumber() == START_ITERATION)
    //     {
    //         playersList = PhotonNetwork.PlayerList;
    //         iterationRendererComponent.assignNames(getPlayerNames());
    //             
    //     }
    //     setDay(START_DAY);
    //     Round round = new Round(playersList);
    //     round.play();
    // }
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    // public void nextPlayerWorks()
    // {
    //     //iterationRendererComponent.hideFinishTurn();
    //     //iterationRendererComponent.hidePlayerIndicator(currentPlayer);
    //     //Board.getInstance().deleteInstantiatedCard();
    //     if (currentPlayer < playersList.Length)
    //     {
    //         PlayerGameplay.startDailyWork();
    //         iterationRendererComponent.showPlayerIndicator(currentPlayer);
    //     }
    //     else
    //     {
    //         currentPlayer = 0;
    //         iterationRendererComponent.showStartNextDayOrPhaseButton();
    //     }
    // }
    //
    // public void advanceDay()
    // {
    //     if (day < MAX_DAYS)
    //     {
    //         setDay(day + 1);
    //         iterationRendererComponent.showPlayerIndicator(currentPlayer);
    //         nextPlayerWorks();
    //     }
    //     else
    //     {
    //         Sprint.getInstance().getGameplayComponent().advanceToSpringReview();
    //     }
    //     iterationRendererComponent.hideStartNextDayOrPhaseButton();
    // }
    //
    // public int getPlayerIndex()
    // {
    //     return currentPlayer;
    // }
    //
    // public Player getCurrentPlayer()
    // {
    //     return playersList[currentPlayer];
    // }
    //
    // public void allowRollDice()
    // {
    //     iterationRendererComponent.showRollButton();
    // }
    //
    // public void rollDices()
    // {
    //     if (PlayerGameplay.playerHasSelectedStory() )
    //     {
    //         iterationRendererComponent.hideRollButton();
    //         int firstRollValue = Dice.getInstance().
    //             getFirstDiceGameplayComponent().rollDice();
    //         int secondRollValue = Dice.getInstance().
    //             getSecondDiceGameplayComponent().rollDice();
    //         setRollValue(firstRollValue + secondRollValue);
    //         //Draw a card and apply changes
    //         int cardDrawn = Board.getInstance().chanceDeck.drawCard();
    //         //Broadcarst Dice and Card Information
    //         //iterationNetworkComponent.sendTurnInformation(rollValue, cardDrawn, PlayerGameplay.workedOnStory.id);
    //         iterationRendererComponent.showFinishTurn();
    //         currentPlayer++;
    //     }
    //     
    // }
    //
    // public void setRollValue(int rollValue)
    // {
    //     this.rollValue = rollValue;
    //     iterationRendererComponent.showRollValue(rollValue);
    // }
    //
    // public int getRollValue()
    // {
    //     return rollValue;
    // }
    //

    //





}
