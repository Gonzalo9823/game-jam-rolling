using UnityEngine;

public class RotateWithMouseOrTouch : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 lastInputPosition;
    private Vector3 initialTouchWorldPos;
    private bool isRotating;
    private float rotationSensitivity = 0.8f;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartRotation(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0) && isRotating)
        {
            RotateCircle(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    StartRotation(touch.position);
                    break;
                case TouchPhase.Moved:
                    if (isRotating)
                    {
                        RotateCircle(touch.position);
                    }
                    break;
                case TouchPhase.Ended:
                    isRotating = false;
                    break;
            }
        }
    }

    private void StartRotation(Vector2 inputPosition)
    {
        lastInputPosition = mainCamera.ScreenToWorldPoint(inputPosition);
        RaycastHit2D hit = Physics2D.Raycast(lastInputPosition, Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            isRotating = true;
            initialTouchWorldPos = lastInputPosition - (Vector2)transform.position;
        }
    }

    private void RotateCircle(Vector2 inputPosition)
    {
        Vector2 currentInputPosition = mainCamera.ScreenToWorldPoint(inputPosition);
        Vector2 currentTouchWorldPos = currentInputPosition - (Vector2)transform.position;
        
        float angle = Vector2.SignedAngle(initialTouchWorldPos, currentTouchWorldPos);
        transform.Rotate(Vector3.forward, angle * rotationSensitivity);
        
        initialTouchWorldPos = currentTouchWorldPos;
    }
}
