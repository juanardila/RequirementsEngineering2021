using TMPro;
using UnityEngine;

public class IterationRendererComponent
{
    private TextMeshProUGUI[] playerNameMeshes;
    private SpriteRenderer[] playerIndicatorSprites;

    private SpriteRenderer rollButton;
    private SpriteRenderer finishTurnButton;
    private SpriteRenderer startNextDayOrPhaseButton;
    private TextMeshProUGUI rollValue;
    private TextMeshProUGUI dayMesh;
    
    public IterationRendererComponent(TextMeshProUGUI[] playerNameMeshes,
        SpriteRenderer[] playerIndicatorSprites, SpriteRenderer rollButton,
        TextMeshProUGUI rollValue, SpriteRenderer finishTurnButton,
        SpriteRenderer startNextDayOrPhaseButton, TextMeshProUGUI dayMesh)
    {
        this.playerNameMeshes = playerNameMeshes;
        this.playerIndicatorSprites = playerIndicatorSprites;
        this.rollButton = rollButton;
        this.rollValue = rollValue;
        this.finishTurnButton = finishTurnButton;
        this.startNextDayOrPhaseButton = startNextDayOrPhaseButton;
        this.dayMesh = dayMesh;
        deactivateAllSprites();
    }

    public void assignNames(string[] playerNames)
    {
        int index = 0;
        foreach (string name in playerNames)
        {
            playerNameMeshes[index++].text = name;
        }
    }

    private void deactivateAllSprites()
    {
        foreach (SpriteRenderer spriteRenderer in playerIndicatorSprites)
        {
            spriteRenderer.enabled = false;
        }

        dayMesh.text = "";
        hideRollButton();
        hideFinishTurn();
        hideStartNextDayOrPhaseButton();
    }

    public void showPlayerIndicator(int playerIndex)
    {
        playerIndicatorSprites[playerIndex].enabled = true;
    }

    public void hidePlayerIndicator(int playerIndex)
    {
        playerIndicatorSprites[playerIndex].enabled = false;
    }

    public void showRollButton()
    {
        rollButton.enabled = true;
    }
   public void hideRollButton()
   {
       rollButton.enabled = false;
   }

    public void showRollValue(int rollValue)
    {
        this.rollValue.text = rollValue.ToString();
    }

    public void showFinishTurn()
    {
        this.finishTurnButton.enabled = true;
    }  
    public void hideFinishTurn()
    {
        this.finishTurnButton.enabled = false;
    }
    
    public void showStartNextDayOrPhaseButton()
    {
        this.startNextDayOrPhaseButton.enabled = true;
    }
    public void hideStartNextDayOrPhaseButton()
    {
        this.startNextDayOrPhaseButton.enabled = false;
    }

    public void setDayMesh(int day)
    {
        dayMesh.text = day.ToString();
    }
}
