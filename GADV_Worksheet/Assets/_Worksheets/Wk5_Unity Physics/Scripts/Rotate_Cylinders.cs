using UnityEngine;

public class Rotate_Cylinders : MonoBehaviour
{
    public float torqueAmount = 10f; // Adjust in Inspector

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.AddTorque(Vector3.up * torqueAmount, ForceMode.Force);
        }
    }
}
