using TMPro;
using UnityEngine;

public class Word : MonoBehaviour
{
    private TextMeshProUGUI tmpText;
    private SpriteRenderer dash;

    // Start is called before the first frame update
    void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
        dash = tmpText.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dash.enabled = !TextManager.words.Contains(tmpText.text);
    }
}
