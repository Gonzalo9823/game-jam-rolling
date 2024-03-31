using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Linq;

public class ClickToChangeTextColor : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI tmpText;
    public Color defaultColor = Color.white;
    public Color clickedColor = Color.red;

    private SpriteRenderer dash;
    public bool used = false;

    void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
        tmpText.color = defaultColor;
        dash = tmpText.GetComponentInChildren<SpriteRenderer>();
    }

    void Update() {
        dash.enabled = used;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!eventData.dragging && used == false)
        {
            if (tmpText.color == defaultColor)
            {
                TextManager.globalText += tmpText.text;
                TextManager.addLetter(gameObject);
                tmpText.color = clickedColor;
            }

            else if (TextManager.clickedLetters.Last().GetInstanceID() == gameObject.GetInstanceID())
            {
                TextManager.globalText = TextManager.globalText.Remove(TextManager.globalText.Length - 1, 1);
                TextManager.clickedLetters.RemoveAt(TextManager.clickedLetters.Count - 1);
                tmpText.color = defaultColor;
            }
        }
    }
}
