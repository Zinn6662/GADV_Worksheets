using UnityEngine;

public class Orb : MonoBehaviour
{
    public float impulse = 10f; // Dummy Value
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb != null && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.forward * impulse, ForceMode.Impulse);
        }
    }
}
