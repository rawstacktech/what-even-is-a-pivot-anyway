using UnityEngine;
using UnityEngine.UI;

public class StarLayout : MonoBehaviour, ILayoutGroup
{
    [Header("Star Layout")]
    [SerializeField] private StarLayoutElement _layoutElementTopLeft;
    [SerializeField] private StarLayoutElement _layoutElementTopRight;
    [SerializeField] private StarLayoutElement _layoutElementMiddle;
    [SerializeField] private StarLayoutElement _layoutElementBottomLeft;
    [SerializeField] private StarLayoutElement _layoutElementBottomRight;

    public void SetLayoutHorizontal()
    {
        SetSizes();
    }

    private void SetSizes()
    {
        SetElementSize(_layoutElementTopLeft);
        SetElementSize(_layoutElementTopRight);
        SetElementSize(_layoutElementMiddle);
        SetElementSize(_layoutElementBottomLeft);
        SetElementSize(_layoutElementBottomRight);
    }

    private void SetElementSize(StarLayoutElement element)
    {
        element.SetSize(element.preferredWidth, element.preferredHeight);
    }

    public void SetLayoutVertical()
    {
        SetSizes();

        _layoutElementTopLeft.SetBottomLeftPosition(
            0,
            RectTransform.rect.height - _layoutElementTopLeft.preferredHeight);

        _layoutElementTopRight.SetBottomLeftPosition(
            RectTransform.rect.width - _layoutElementTopRight.preferredWidth,
            RectTransform.rect.height - _layoutElementTopRight.preferredHeight);

        _layoutElementMiddle.SetBottomLeftPosition(
            RectTransform.rect.width / 2 - _layoutElementMiddle.preferredWidth / 2,
            RectTransform.rect.height / 2 - _layoutElementMiddle.preferredHeight / 2);

        _layoutElementBottomLeft.SetBottomLeftPosition(
            0,
            0);

        _layoutElementBottomRight.SetBottomLeftPosition(
            RectTransform.rect.width - _layoutElementBottomRight.preferredWidth,
            0);
    }

    private RectTransform RectTransform
    {
        get { return GetComponent<RectTransform>(); }
    }
}
