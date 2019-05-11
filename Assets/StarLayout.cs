using UnityEngine;
using UnityEngine.UI;

public class StarLayout : MonoBehaviour, ILayoutGroup
{
    [Header("Star Layout")]
    [SerializeField] private LayoutElement _layoutElementTopLeft;
    [SerializeField] private LayoutElement _layoutElementTopRight;
    [SerializeField] private LayoutElement _layoutElementMiddle;
    [SerializeField] private LayoutElement _layoutElementBottomLeft;
    [SerializeField] private LayoutElement _layoutElementBottomRight;

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

    private void SetElementSize(LayoutElement element)
    {
        element.GetComponent<RectTransform>().sizeDelta =
            new Vector2(element.preferredWidth, element.preferredHeight);
    }

    public void SetLayoutVertical()
    {
        SetSizes();

        _layoutElementTopLeft.GetComponent<RectTransform>().SetPosition(
            0,
            RectTransform.rect.height - _layoutElementTopLeft.preferredHeight);

        _layoutElementTopRight.GetComponent<RectTransform>().SetPosition(
            RectTransform.rect.width - _layoutElementTopRight.preferredWidth,
            RectTransform.rect.height - _layoutElementTopRight.preferredHeight);

        _layoutElementMiddle.GetComponent<RectTransform>().SetPosition(
            RectTransform.rect.width / 2 - _layoutElementMiddle.preferredWidth / 2,
            RectTransform.rect.height / 2 - _layoutElementMiddle.preferredHeight / 2);

        _layoutElementBottomLeft.GetComponent<RectTransform>().SetPosition(
            0,
            0);

        _layoutElementBottomRight.GetComponent<RectTransform>().SetPosition(
            RectTransform.rect.width - _layoutElementBottomRight.preferredWidth,
            0);
    }

    private RectTransform RectTransform
    {
        get { return GetComponent<RectTransform>(); }
    }
}
