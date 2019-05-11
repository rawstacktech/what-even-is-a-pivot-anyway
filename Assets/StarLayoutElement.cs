using UnityEngine;
using UnityEngine.UI;

public class StarLayoutElement : MonoBehaviour, ILayoutElement
{
    [Header("Star Layout Element")]
    [SerializeField] private float _width;
    [SerializeField] private float _height;

    public float minWidth { get { return _width; } }

    public float preferredWidth { get { return _width; } }

    public float flexibleWidth { get { return 0; } }

    public float minHeight { get { return 0; } }

    public float preferredHeight { get { return _height; } }

    public float flexibleHeight { get { return _height; } }

    public int layoutPriority { get { return 1; } }

    public void CalculateLayoutInputHorizontal()
    {
    }

    public void CalculateLayoutInputVertical()
    {
    }

    public void SetSize(float width, float height)
    {
        RectTransform.sizeDelta = new Vector2(width, height);
    }

    public void SetBottomLeftPosition(float x, float y)
    {
        RectTransform.anchoredPosition =
            // Align the bottom left of the element
            new Vector2(RectTransform.rect.width, RectTransform.rect.height) * RectTransform.pivot
            // With the bottom left of the parent
            - new Vector2(Parent.rect.width, Parent.rect.height) * RectTransform.pivot
            // Now place in desired location
            + new Vector2(x, y);
    }

    private RectTransform Parent
    {
        get { return (RectTransform)RectTransform.parent; }
    }

    private RectTransform RectTransform
    {
        get { return GetComponent<RectTransform>(); }
    }
}
