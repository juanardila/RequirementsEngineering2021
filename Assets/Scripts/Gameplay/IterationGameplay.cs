using Photon.Pun;
using Photon.Realtime;
public class IterationGameplay
{
    private IterationRendererComponent iterationRendererComponent;
    private Player[] playersList;
    private int day;
    private int currentPlayer;

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

    
    
    


}
