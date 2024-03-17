using UnityEngine;

public class CircleSegmenter : MonoBehaviour
{
    public GameObject segmentPrefab;
    public int numberOfSegments = 24;
    public float circleRadius = 5f;

    void Start()
    {
        CreateSegments();
    }

    void CreateSegments()
    {
        float lineLength = circleRadius * 2;

        for (int i = 0; i < numberOfSegments; i++)
        {
            float angle = i * 360f / numberOfSegments;
            GameObject segment = Instantiate(segmentPrefab, transform.position, Quaternion.Euler(0f, 0f, angle), transform);

            segment.transform.localPosition = new Vector3(0f, 0f, 0f);
            segment.transform.localScale = new Vector3(segment.transform.localScale.x, lineLength, segment.transform.localScale.z);

            segment.transform.localPosition = new Vector3(0f, 0f, -0.1f);
        }

        segmentPrefab.SetActive(false);
    }
}
