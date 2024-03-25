using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ClickToChangeTextColor : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI tmpText;
    public Color defaultColor = Color.white;
    public Color clickedColor = Color.red;

    void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
        tmpText.color = defaultColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Change the color on click if it's not a dragging event
        if (!eventData.dragging)
        {
            tmpText.color = tmpText.color == defaultColor ? clickedColor : defaultColor;
        }
    }
}
