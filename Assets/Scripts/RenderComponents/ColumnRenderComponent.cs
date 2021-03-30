using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnRenderComponent
{
    private static Color defaultColor = Color.white;
    private static Color allowNewStory = Color.green;
    private SpriteRenderer spriteRenderer;

    public ColumnRenderComponent(SpriteRenderer spriteRenderer)
    {
        this.spriteRenderer = spriteRenderer;
        spriteRenderer.color = defaultColor;
    }

    public void paintToAllowNewStory()
    {
        spriteRenderer.color = allowNewStory;
    }

    public void paintToDefault()
    {
        spriteRenderer.color = defaultColor;
    }
}
