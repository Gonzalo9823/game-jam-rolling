using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TextManager : MonoBehaviour
{
    public static List<string> words = new List<string> { "ELEFANTE", "SOL", "MONTAÑA", "ARBOL", "LIBRO", "COMPUTADORA", "RIO", "FELICIDAD", "ESTRELLAS", "LUNA" };
    public static List<char> availableLetters = new List<char> { 'E', 'L', 'E', 'F', 'A', 'N', 'T', 'E', 'S', 'O', 'L', 'M', 'O', 'N', 'T', 'A', 'Ñ', 'A', 'A', 'R', 'B', 'O', 'L', 'L', 'I', 'B', 'R', 'O', 'C', 'O', 'M', 'P', 'U', 'T', 'A', 'D', 'O', 'R', 'A', 'R', 'I', 'O', 'F', 'E', 'L', 'I', 'C', 'I', 'D', 'A', 'D', 'E', 'S', 'T', 'R', 'E', 'L', 'L', 'A', 'S', 'L', 'U', 'N', 'A' };
    public static string globalText = "";
    public static List<GameObject> clickedLetters = new List<GameObject>();
    public TextMeshProUGUI displayText;

    void Start()
    {
        displayText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Shuffle(availableLetters);
        displayText.text = globalText;
    }

    public static void addLetter(GameObject letter)
    {
        clickedLetters.Add(letter);
        string word = GetLettersAsString();

        if (words.Contains(word))
        {
            int idx = words.IndexOf(word);
            words.RemoveAt(idx);

            foreach (var clickecLetter in clickedLetters)
            {
                ClickToChangeTextColor myScript = clickecLetter.GetComponent<ClickToChangeTextColor>();
                myScript.used = true;
            }

            clickedLetters.Clear();
            globalText = "";
        }
    }

    private static string GetLettersAsString()
    {
        string result = "";

        foreach (GameObject letterObj in clickedLetters)
        {
            TextMeshProUGUI textMesh = letterObj.GetComponent<TextMeshProUGUI>();
            result += textMesh.text;
        }

        return result;
    }

    public static void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
