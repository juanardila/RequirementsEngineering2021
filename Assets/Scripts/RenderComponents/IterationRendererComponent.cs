using TMPro;
using UnityEngine;

public class IterationRendererComponent
{
    private TextMeshProUGUI[] playerNameMeshes;
    private SpriteRenderer[] playerIndicatorSprites;

    public IterationRendererComponent(TextMeshProUGUI[] playerNameMeshes,
        SpriteRenderer[] playerIndicatorSprites)
    {
        this.playerNameMeshes = playerNameMeshes;
        this.playerIndicatorSprites = playerIndicatorSprites;
        deactivateAllIndicators();
    }

    public void assignNames(string[] playerNames)
    {
        int index = 0;
        foreach (string name in playerNames)
        {
            playerNameMeshes[index++].text = name;
        }
    }

    private void deactivateAllIndicators()
    {
        foreach (SpriteRenderer spriteRenderer in playerIndicatorSprites)
        {
            spriteRenderer.enabled = false;
        }
    }

    public void showPlayerIndicator(int playerIndex)
    {
        playerIndicatorSprites[playerIndex].enabled = true;
    }

    public void hidePlayerIndicator(int playerIndex)
    {
        playerIndicatorSprites[playerIndex].enabled = false;
    }
    
    
}
