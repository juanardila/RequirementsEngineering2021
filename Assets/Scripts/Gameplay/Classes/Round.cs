using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using Photon.Realtime;

public class Round
{
    public class RoundFlags
    {
        public bool substractOneFromEveryOneThisTurn;
        public List<int> skipsTurn;
        public bool everyOneSkipsTurn;

        public RoundFlags()
        {
            this.substractOneFromEveryOneThisTurn = false;
            this.skipsTurn = new List<int>();
            this.everyOneSkipsTurn = false;
        }

        public RoundFlags(RoundFlags other)
        {
            this.substractOneFromEveryOneThisTurn = other.substractOneFromEveryOneThisTurn;
            this.skipsTurn = new List<int>(other.skipsTurn);
            this.everyOneSkipsTurn = other.everyOneSkipsTurn;
        }
    }

    
    private Player[] playerList;
    private int playerPlayingIndex;
    private int playersPlaying;
    private IterationGameplayComponent iterationGamplayComponent;
    private List<UserStoryGameplayComponent> playiedStories;
    private IterationRendererComponent iterationRendererComponent;
    private Turn turn;
    private int localPlayerIndex;
    public RoundFlags roundFlags;
    
    public static RoundFlags nextRoundFlags = new RoundFlags(); 
    
    public Round(Player[] playerList,
        IterationGameplayComponent iterationGameplayComponent,
        IterationRendererComponent iterationRendererComponent)
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
        roundFlags = new RoundFlags(Round.nextRoundFlags);
        Round.nextRoundFlags = new RoundFlags();
        turn = new Turn(iterationRendererComponent, this);
        if (roundFlags.skipsTurn.Contains(playerPlayingIndex))
        {
            playerPlayingIndex++;
        }

        if (!isOver())
        {
            turn.play(playerPlayingIndex);    
        }
        else
        {
            finishLocalTurn();
        }
    }

    public void end()
    {
        
    }

    public void finishLocalTurn()
    {
        playerPlayingIndex++;
        if (roundFlags.skipsTurn.Contains(playerPlayingIndex))
        {
            playerPlayingIndex++;
        }

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
    
    public void finishRemoteTurn(int userStoryId, int rollValue, int chanceCardId)
    {
        turn.setDrawnCardId(chanceCardId);
        turn.setSelectedUserStory(UserStoryGameplayComponent.getUserStoryGameplayComponent(userStoryId));
        
        
        finishLocalTurn();
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
