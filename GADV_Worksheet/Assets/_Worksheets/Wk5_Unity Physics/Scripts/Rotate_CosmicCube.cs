using UnityEngine;

public class Rotate_CosmicCube : MonoBehaviour
{
    public float angularSpeed = 90f; // degrees per second
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            // Set angular velocity to a fixed value (radians per second)
            Vector3 spin = new Vector3(1, 1, 1).normalized * angularSpeed * Mathf.Deg2Rad;
            rb.angularVelocity = spin;
        }
    }
}
