using UnityEngine;
using TMPro;

public class TriangleRingCreator : MonoBehaviour
{
    public GameObject trianglePrefab;
    public float radius = 5f;
    public int numberOfTriangles;

    void Start()
    {
        FitTrianglesToCircle();
    }

    void FitTrianglesToCircle()
    {
        for (int i = 0; i < numberOfTriangles; i++)
        {
            float angle = i * 360f / numberOfTriangles;
            float additionalRotation = 180f;

            GameObject triangle = Instantiate(trianglePrefab, trianglePrefab.transform.position, Quaternion.identity, transform);
            triangle.transform.rotation = Quaternion.Euler(0, 0, angle + additionalRotation);

            TextMeshProUGUI textComponent = triangle.GetComponentInChildren<TextMeshProUGUI>(true);

            if (TextManager.availableLetters.Count == 0)
            {
                char randLetter = (char)Random.Range('A', 'Z');
                textComponent.text = "" + randLetter;
            }
            else
            {
                int randIdx = Random.Range(0, TextManager.availableLetters.Count - 1);
                textComponent.text = "" + TextManager.availableLetters[randIdx];
                TextManager.availableLetters.RemoveAt(randIdx);
            }
        }

        trianglePrefab.SetActive(false);
    }
}
