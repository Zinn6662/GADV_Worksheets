using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Projectile 
{    private float speed;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

        public void AutoFire()
    {
        speed = 100f;
        Debug.Log("Speed was zero. AutoFire set speed to 100 and launched!");
        Fire();
    }

    public void Fire()
    {
        if (speed > 0)
        {
            Debug.Log("Firing projectile at speed " + speed);
        }
        else if (speed == 0)
        {
            AutoFire();
        }
        else
        {
            Debug.Log("Cannot fire: speed too low.");
        }
    }

}

public class PlayerController
{
    private int health;

    public void Health(int newHealth)
    {
        if (newHealth < 11)
        {
            health = newHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        if ((health - damage) > 0)
        {
            health = health - damage;
        }
        else
        {
            health = 0;
        }
    }

    public void GetHealth()
    {
        Debug.Log("Player Health is" + health);
    }
}
