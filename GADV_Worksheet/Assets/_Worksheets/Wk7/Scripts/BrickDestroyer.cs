using UnityEngine;

public class BrickDestroyer : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Ball"
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Destroy the brick
            Destroy(gameObject);
        }
    }
}
