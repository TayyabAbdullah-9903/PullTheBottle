using UnityEngine;

public class BottleDrag : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D rb;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);

            rb.MovePosition(pos);
        }
    }
}