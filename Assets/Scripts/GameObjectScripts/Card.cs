using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
public class Card : MonoBehaviour
{
    public TextMeshProUGUI titleMesh;
    public TextMeshProUGUI descriptionMesh;

    private ChanceCardGameplayComponent _cardGameplay;
    private ChanceCardRenderComponent _chanceCardRenderComponent;

    public void instantiateOnBoard(ChanceCardGameplayComponent chanceCardGameplayComponent,
        ChanceCardRenderComponent chanceCardRenderComponent)
    {
        this._cardGameplay = chanceCardGameplayComponent;
        this._chanceCardRenderComponent = chanceCardRenderComponent;
        this._chanceCardRenderComponent.draw(GetComponent<SpriteRenderer>(),
            titleMesh, descriptionMesh);
    }

    public void delete()
    {
        Destroy(this);
    }

    public ChanceCardGameplayComponent getChanceCardGameplayComponent()
    {
        return _cardGameplay;
    }
}