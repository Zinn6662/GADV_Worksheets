using UnityEngine;

public class CosmicCube : MonoBehaviour
{
    public Material defaultMaterial;
    public Material collisionMaterial;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null && defaultMaterial != null)
        {
            rend.material = defaultMaterial;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null && collisionMaterial != null && rend != null)
        {
            rend.material = collisionMaterial;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody != null && defaultMaterial != null && rend != null)
        {
            rend.material = defaultMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
