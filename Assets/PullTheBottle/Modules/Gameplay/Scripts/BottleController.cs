using UnityEngine;

public class BottleController : MonoBehaviour
{
    [SerializeField] private Camera cam = null;

    [Header("Drag Settings")]
    [SerializeField] private float dragSensitivity = 0.2f; // SMALL movement
    [SerializeField] private float maxDistance = 3f;

    private Vector2 lastMousePos = new Vector2();
    private Vector2 startPosition = new Vector2();

    [SerializeField] private float currentDistance = 0;
    private bool isBroken = false;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (isBroken) return;
        HandleDrag();
    }

    private void HandleDrag()
    {
        Vector2 inputPos;
        bool isHolding = false;

  

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            inputPos = cam.ScreenToWorldPoint(touch.position);
            isHolding = touch.phase == TouchPhase.Began ||
                        touch.phase == TouchPhase.Moved ||
                        touch.phase == TouchPhase.Stationary;

            if (touch.phase == TouchPhase.Began)
            {
                lastMousePos = inputPos;
            }
        }

        else
        {
            inputPos = cam.ScreenToWorldPoint(Input.mousePosition);
            isHolding = Input.GetMouseButton(0);

            if (Input.GetMouseButtonDown(0))
            {
                lastMousePos = inputPos;
            }
        }

        if (isHolding)
        {
            Vector2 delta = inputPos - lastMousePos;

            Vector2 newPos = (Vector2)transform.position + delta * dragSensitivity;

            Vector2 offset = newPos - startPosition;
            offset = Vector2.ClampMagnitude(offset, maxDistance);

            transform.position = startPosition + offset;

            currentDistance = offset.magnitude;

            lastMousePos = inputPos;
        }


        if ((Input.touchCount == 0 && Input.GetMouseButtonUp(0)) ||
            (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            ResetBottle();
        }
    }
    private void ResetBottle()
    {
        transform.position = startPosition;
        currentDistance = 0;
    }

    public float GetCurrentDistance()
    {
        return currentDistance;
    }

    public void ChangeBrokenBool()
    {
        isBroken = true;
    }
}