using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 2;
    private int currentHealth;

    public Transform[] waypoints;
    public float speed = 2f;
    private int index = 0;

    public int contactDamage = 1;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (waypoints.Length > 0)
        {
            Transform target = waypoints[index];
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, target.position) < 0.1f)
                index = (index + 1) % waypoints.Length;
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        GameManager.Instance.AddKill();
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            PlayerHealth p = other.collider.GetComponent<PlayerHealth>();
            if (p != null) p.TakeDamage(contactDamage);
        }
    }
}
