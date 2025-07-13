using UnityEngine;

public class AsteroidRotator : MonoBehaviour
{
    public float rotationSpeed = 200f; // Default rotation speed

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

    }
    
}
