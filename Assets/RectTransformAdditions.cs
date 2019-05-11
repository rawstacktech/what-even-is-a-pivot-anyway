using UnityEngine;

public static class RectTransformAdditions
{
    public static void SetPosition(this RectTransform rectTransform, float x, float y)
    {
        RectTransform parent = (RectTransform)rectTransform.parent;
        rectTransform.anchoredPosition =
            new Vector2(rectTransform.rect.width, rectTransform.rect.height) * rectTransform.pivot
            - new Vector2(parent.rect.width, parent.rect.height) * rectTransform.pivot
            + new Vector2(x, y);
    }
}