using TMPro;
using UnityEngine;

public class IterationRendererComponent
{
    private TextMeshProUGUI[] playerNameMeshes;
    private SpriteRenderer[] playerIndicatorSprites;

    private SpriteRenderer rollButton;
    private TextMeshProUGUI rollValue;
    
    public IterationRendererComponent(TextMeshProUGUI[] playerNameMeshes,
        SpriteRenderer[] playerIndicatorSprites, SpriteRenderer rollButton,
        TextMeshProUGUI rollValue)
    {
        this.playerNameMeshes = playerNameMeshes;
        this.playerIndicatorSprites = playerIndicatorSprites;
        this.rollButton = rollButton;
        this.rollValue = rollValue;
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
        rollButton.enabled = false;
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

    public void showRollValue(int rollValue)
    {
        this.rollValue.text = rollValue.ToString();
    }
    
    
}
