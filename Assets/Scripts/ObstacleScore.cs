using UnityEngine;
//big wheel add score
public class ScoreObstacle : MonoBehaviour
{
    public int scoreValue = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("ball"))
            return;

        FindFirstObjectByType<ScoreManager>().AddScore(scoreValue);
    }
}