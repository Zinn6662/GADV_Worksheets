using UnityEngine;

public class BallInitializer : MonoBehaviour
{

    private Rigidbody2D MyRb { get; set; }
    public float speed = 500f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        MyRb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    private void SetRandomTrajectory()
    {   
        Vector2 force = Vector2.zero;
        // Use a symmetric range for x
        force.x = Random.Range(-1f, 1f);
        force.y = -1;

        // Prevent the ball from going too horizontally
        if (Mathf.Abs(force.x) < 0.2f)
            force.x = Mathf.Sign(force.x) * 0.2f;

        MyRb.AddForce(force.normalized * speed);
    }
}
