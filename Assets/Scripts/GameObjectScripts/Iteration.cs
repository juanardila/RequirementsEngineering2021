
using System;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class Iteration : MonoBehaviour
{
    public SpriteRenderer player1Indicator;
    public SpriteRenderer player2Indicator;
    public SpriteRenderer player3Indicator;
    public SpriteRenderer player4Indicator;
    public SpriteRenderer player5Indicator;
    public SpriteRenderer player6Indicator;
    public TextMeshProUGUI player1Name;
    public TextMeshProUGUI player2Name;
    public TextMeshProUGUI player3Name;
    public TextMeshProUGUI player4Name;
    public TextMeshProUGUI player5Name;
    public TextMeshProUGUI player6Name;
    public SpriteRenderer rollButton;
    public TextMeshProUGUI rollValue;
    public SpriteRenderer finishTurnButton;
    public SpriteRenderer nextDayOrPhaseButton;
    public TextMeshProUGUI dayMesh;


    private IterationGameplayComponent _iterationGameplayComponent;
    private IterationRendererComponent _iterationRendererComponent;
    
    private static Iteration _instance;

    public static Iteration getInstance()
    {
        return _instance;
    }

    //Singleton pattern
    //https://gamedev.stackexchange.com/questions/116009/in-unity-how-do-i-correctly-implement-the-singleton-pattern
    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            SpriteRenderer[] playerIndicators = {player1Indicator, 
                player2Indicator,
                player3Indicator,
                player4Indicator,
                player5Indicator,
                player6Indicator };
            TextMeshProUGUI[] playerNameMeshes = { player1Name,
                player2Name,
                player3Name,
                player4Name,
                player5Name,
                player6Name };
            _iterationRendererComponent = new IterationRendererComponent(playerNameMeshes,
                playerIndicators, rollButton, rollValue, finishTurnButton, nextDayOrPhaseButton,
                dayMesh);
            _iterationGameplayComponent = new IterationGameplayComponent(_iterationRendererComponent);
            _instance = this;
        }
        
    }

    public IterationGameplayComponent getGameplaycomponent()
    {
        return _iterationGameplayComponent;
    }


    
    private Iteration(){}
}
