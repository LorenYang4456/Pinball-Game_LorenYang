using UnityEngine;
using UnityEngine.InputSystem;

public class FlipperController : MonoBehaviour
{
    [Header("Flipper Settings")]
    public float restAngle = 0f;
    public float activeAngle = 45f;
    public float flipSpeed = 1000f;

    private Rigidbody2D rb;
    private float targetAngle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        targetAngle = restAngle;
    }

    private void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.zKey.isPressed)
        {
            targetAngle = activeAngle;
        }
        else
        {
            targetAngle = restAngle;
        }
    }

    private void FixedUpdate()
    {
        if (rb == null)
            return;

        float currentAngle = rb.rotation;

        float newAngle = Mathf.MoveTowardsAngle(
            currentAngle,
            targetAngle,
            flipSpeed * Time.fixedDeltaTime
        );

        rb.MoveRotation(newAngle);
    }
}