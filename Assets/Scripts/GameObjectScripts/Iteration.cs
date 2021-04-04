
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

    private IterationGameplay _iterationGameplay;
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
                playerIndicators, rollButton, rollValue);
            _iterationGameplay = new IterationGameplay(_iterationRendererComponent);
            _instance = this;
        }
        
    }

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

    public IterationGameplay getGameplaycomponent()
    {
        return _iterationGameplay;
    }

    private Iteration(){}
}
