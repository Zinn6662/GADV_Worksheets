using UnityEngine;

public class AsteroidColourTinter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Access the SpriteRenderer component
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (spriteRenderer.color == Color.white)
            {
                spriteRenderer.color = Color.blue;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
        }
    }
}
