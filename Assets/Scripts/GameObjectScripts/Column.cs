using UnityEngine;

public class Column : MonoBehaviour
{
    private ColumnRenderComponent _columnRenderComponent;
    private ColumnGameplayComponent _columnGameplayComponent;
    private CollumnCollisionComponent _columnCollisionComponent;

    private void Awake()
    {
        _columnRenderComponent = new ColumnRenderComponent(GetComponent<SpriteRenderer>(),
            GetComponent<Transform>().position, GetComponent<BoxCollider2D>());
        _columnGameplayComponent = new ColumnGameplayComponent(tag, _columnRenderComponent);
        _columnCollisionComponent = new CollumnCollisionComponent(_columnRenderComponent, _columnGameplayComponent);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _columnCollisionComponent.onCollisionEnter(other);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _columnCollisionComponent.onCollisionExit(other);
    }

    public ColumnGameplayComponent getGameplayComponent()
    {
        return _columnGameplayComponent;
    }
}
