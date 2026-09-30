
using UnityEngine;

public class RailController : MonoBehaviour
{
    [Header("Rail Path")]
    public Transform[] waypoints;

    [Header("Movement")]
    public float speed = 5f;

    private Rigidbody2D ballRb;
    private int currentIndex;
    private bool isOnRail;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("ball"))
            return;

        ballRb = other.GetComponent<Rigidbody2D>();

        if (ballRb == null)
            return;

        //start moving on the rail
        currentIndex = 0;
        isOnRail = true;

        //stop all other movement when hit the rail
        ballRb.linearVelocity = Vector2.zero;
        ballRb.gravityScale = 0f;
    }

    private void FixedUpdate()
    {
        if (!isOnRail || ballRb == null)
            return;

        MoveBallAlongRail();
    }

    private void MoveBallAlongRail()
    {
        if (currentIndex >= waypoints.Length)
        {
            ExitRail();
            return;
        }

        Vector2 target =
            waypoints[currentIndex].position;

        Vector2 currentPosition =
            ballRb.position;

        Vector2 direction =
            (target - currentPosition).normalized;

        float distance =
            Vector2.Distance(currentPosition, target);

        float moveDistance =
            speed * Time.fixedDeltaTime;

        if (distance <= moveDistance)
        {
            ballRb.MovePosition(target);
            currentIndex++;
        }
        else
        {
            Vector2 nextPosition =
                currentPosition + direction * moveDistance;

            ballRb.MovePosition(nextPosition);
        }
    }

    private void ExitRail()
    {
        isOnRail = false;

        //give gravity back
        ballRb.gravityScale = 1f;

        //exit direction inertia
        Vector2 exitDirection =
            (waypoints[waypoints.Length - 1].position -
             waypoints[waypoints.Length - 2].position).normalized;

        ballRb.linearVelocity = exitDirection * speed;

        ballRb = null;
    }
}
