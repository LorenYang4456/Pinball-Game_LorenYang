using UnityEngine;

public class FlipperBounce : MonoBehaviour
{
    public float bounceForce = 8f;

    private void OnCollisionEnter2D(
        Collision2D collision
    )
    {
        if (!collision.gameObject.CompareTag("ball"))
            return;

        Rigidbody2D ballRb =
            collision.gameObject.GetComponent<Rigidbody2D>();

        if (ballRb == null)
            return;

        //force on pivot to ball(the tip of the flipper)
        Vector2 direction =
            ballRb.position - (Vector2)transform.position;

        direction.Normalize();

        //up
        direction =
            (direction + Vector2.up * 0.5f).normalized;

        //add force
        ballRb.AddForce(
            direction * bounceForce,
            ForceMode2D.Impulse
        );
    }
}