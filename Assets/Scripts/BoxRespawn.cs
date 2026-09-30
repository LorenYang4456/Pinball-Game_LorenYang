using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("ball"))
            return;

        Rigidbody2D ballRb = other.GetComponent<Rigidbody2D>();

        if (ballRb == null)
            return;

        //spawnpoint teleport
        ballRb.position = spawnPoint.position;
        
        ScoreManager scoreManager =
            FindFirstObjectByType<ScoreManager>();

        if (scoreManager != null)
        {
            scoreManager.ResetScore();
        }
    }
}