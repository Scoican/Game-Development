using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy stats")]
    public float startSpeed = 10f;
    public int valueOnDeath = 50;
    public float startHealth = 100;
    private bool isDead = false;

    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float health;

    [Header("Enemy graphics")]
    public GameObject deathParticles;
    public Image healthBar;


    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        WaveSpawnerScript.EnemiesAlive--;
        PlayerStats.Money += this.valueOnDeath;
        Destroy(gameObject);
        GameObject particles = (GameObject)Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(particles, 5f);
        
    }

    public void Slow(float factor)
    {
        speed = startSpeed * (1f - factor);
    }
}