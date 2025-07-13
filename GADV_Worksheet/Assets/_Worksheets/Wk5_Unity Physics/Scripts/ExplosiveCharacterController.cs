using UnityEngine;
using System.Collections;

public class ExplosiveCharacterController : MonoBehaviour
{
    CharacterController controller;

    // Variables for moving the player
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    // Explosion variables
    public float radius = 100.0f;
    public float power = 10000.0f;

    // Kick variables
    public float kickStrength = 10.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.detectCollisions = false; // Only set to false if you want to ignore collisions!
    }

    void CheckExplosion()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Find all colliders within the explosion radius
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            // Apply explosion force to all rigidbodies found
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.attachedRigidbody;
                if (rb != null)
                {
                    rb.AddExplosionForce(power, transform.position, radius, 3.0f, ForceMode.Impulse);
                }
            }
        }
    }

    void Kick()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Define the center of the kick area a short distance in front of the player
            Vector3 kickCenter = transform.position + transform.forward * 2.0f; // 2.0f is the kick reach, adjust as needed
            float kickRadius = 2.0f; // Area of effect for the kick, adjust as needed

            Collider[] colliders = Physics.OverlapSphere(kickCenter, kickRadius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    // Apply force in the player's forward direction
                    rb.AddForce(transform.forward * kickStrength, ForceMode.Impulse);
                }
            }
        }
    }

    void FixedUpdate()
    {
        CheckExplosion();
        Kick();

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        if (moveDirection != Vector3.zero)
        {
            // Only rotate on the horizontal plane
            Vector3 lookDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
