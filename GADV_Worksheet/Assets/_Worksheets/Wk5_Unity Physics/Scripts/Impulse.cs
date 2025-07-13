using UnityEngine;

public class Impulse : MonoBehaviour
{
    public float force = 10f;
    public float torque = 10f; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb == null) return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(transform.forward * force, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.AddForce(-transform.forward * force, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddForce(-transform.right * force, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.AddForce(transform.right * force, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * force, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            // Clockwise rotation (negative Y torque)
            rb.AddTorque(Vector3.down * torque, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            // Anti-clockwise rotation (positive Y torque)
            rb.AddTorque(Vector3.up * torque, ForceMode.Impulse);
        }
    }
}
