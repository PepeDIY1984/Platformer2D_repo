using UnityEngine;

public class HeadIdleFlip : MonoBehaviour
{
    [Header("Idle float")]
    public float floatAmplitude = 0.1f; // cuánto sube/baja
    public float floatSpeed = 2f;       // velocidad del idle

    Vector3 startPos;
    SpriteRenderer sr;

    void Start()
    {
        startPos = transform.localPosition;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // --- Idle flotante ---
        float offset = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.localPosition = startPos + Vector3.up * offset;

        // --- Flip dirección ---
        if (Input.GetKey(KeyCode.A))
            sr.flipX = true;

        if (Input.GetKey(KeyCode.D))
            sr.flipX = false;
    }
}
