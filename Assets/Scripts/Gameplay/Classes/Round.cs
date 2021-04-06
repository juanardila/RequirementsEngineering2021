using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using Photon.Realtime;

public class Round
{
    struct RoundFlags
    {
        bool substractOneFromEveryOneThisTurn;
        Player skipsTurn;
        bool everyOneSkipsTurn;
    };

    
    private Player[] playerList;
    private int playerPlayingIndex;
    private int playersPlaying;
    private IterationGameplayComponent iterationGamplayComponent;
    private List<UserStoryGameplayComponent> playiedStories;
    private IterationRendererComponent iterationRendererComponent;
    private Turn turn;
    private int localPlayerIndex;
    
    public Round(Player[] playerList,
        IterationGameplayComponent iterationGameplayComponent,
        IterationRendererComponent iterationRendererComponent )
    {
        this.playiedStories = new List<UserStoryGameplayComponent>();
        this.playerList = playerList;
        playerPlayingIndex = 0;
        localPlayerIndex = Array.FindIndex(playerList, player => player.Equals(PhotonNetwork.LocalPlayer));
        playersPlaying = playerList.Length;
        this.iterationRendererComponent = iterationRendererComponent;
        this.iterationGamplayComponent = iterationGameplayComponent;
    }

    public bool localPlayerIsWorking()
    {
        return playerPlayingIndex == localPlayerIndex;
    }

    public void start()
    {
        turn = new Turn(iterationRendererComponent, this);
        turn.play(playerPlayingIndex);
    }

    public void end()
    {
        
    }

    public void finishLocalTurn()
    {
        playerPlayingIndex++;
        if (!isOver())
        {
            turn = new Turn(iterationRendererComponent, this);
            iterationRendererComponent.showPlayerIndicator(playerPlayingIndex);
        }
        else
        {
            iterationRendererComponent.showStartNextDayOrPhaseButton();    
        }
    }
    
    
    
    public bool isOver()
    {
        return playerPlayingIndex >= playersPlaying;
    }

    public void endRound()
    {
        iterationGamplayComponent.endIteration();
    }

    public Turn getTurn()
    {
        return turn;
    }
}
