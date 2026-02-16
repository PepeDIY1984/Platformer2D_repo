using UnityEngine;

public class WheelRotate2D : MonoBehaviour
{
    [SerializeField] float degreesPerSecond = 360f; // velocidad de giro

    void Update()
    {
        float dir = 0f;
        if (Input.GetKey(KeyCode.A)) dir = 1f;   // A => gira "hacia un lado"
        if (Input.GetKey(KeyCode.D)) dir = -1f;  // D => al contrario

        if (dir != 0f)
            transform.Rotate(0f, 0f, dir * degreesPerSecond * Time.deltaTime);
    }
}
