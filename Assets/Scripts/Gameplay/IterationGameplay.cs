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
        setDay(FIRST_DAY);
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
            if (Round.nextRoundFlags.everyOneSkipsTurn)
            {
                setDay(day + 1);
                Round.nextRoundFlags = new Round.RoundFlags();
            }
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

}
