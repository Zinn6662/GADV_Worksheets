using UnityEngine;

public class _PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    public Material greenMaterial;
    public Material redMaterial;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

        CheckLineOfSight();
    }

    void CheckLineOfSight()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        RaycastHit hit;

        foreach (GameObject enemy in enemies)
        {
            Renderer enemyRenderer = enemy.GetComponent<Renderer>();
            if (enemyRenderer != null)
            {
                enemyRenderer.material = redMaterial;
            }
        }

        foreach (GameObject enemy in enemies)
        {
            Vector3 direction = enemy.transform.position - transform.position;
            Debug.DrawRay(transform.position, direction, Color.red, 0.1f);

            Renderer enemyRenderer = enemy.GetComponent<Renderer>();
            if (enemyRenderer == null) continue;

            if (Physics.Raycast(transform.position, direction.normalized, out hit, 30f))
            {
                if (hit.collider.gameObject == enemy)
                {
                    Debug.DrawRay(transform.position, direction, Color.green, 0.1f);
                    enemyRenderer.material = greenMaterial;
                }
            }
        }
    }
}

