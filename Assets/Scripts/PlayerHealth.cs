using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int health = 100;
    public float force = 150f, forceTorque = 100f;
    public static bool death = false;
    private Rigidbody rb;
    public RectTransform healthBar;
    public bool isDamage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isDamage = true;
    }

    public void TakeDamage(int damage)
    {
        
        if (isDamage)
        {
            health -= damage;
            // healthBar.offsetMax = new Vector2(-1f * 420f * (100 - health) / 100f, 0f);
            SetHealthBar();
            
            if (health <= 0 && !death)
            {
                death = true;
                rb.constraints = RigidbodyConstraints.None;
                rb.AddForce(Vector3.up * force);
                rb.AddTorque(Vector3.back * forceTorque);
                gameObject.tag = "Finish";
            }
        }
        
    }
    

    public void Heal(int heal)
    {
        health += heal;
        if (health > 100) health = 100;
        SetHealthBar();
    }

    public void SetHealthBar()
    {
        healthBar.offsetMax = new Vector2(-1f * 420f * (100 - health) / 100f, 0f);
    }

}
