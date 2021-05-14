using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    public float startSpeed = 10f;
    public int moneyGain = 50;
    public GameObject deathEffect;
    public float startHealth = 100;
    private float health;
    private bool isDead = false;
    [Header("Unity Stuff")]
    public Image healthBar;
    private void Start()
    {
        health = startHealth;
        speed = startSpeed;
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
    public void Slow(float percentage)
    {
        speed = startSpeed * (1f - percentage);
    }
    private void Die()
    {
        isDead = true;
        PlayerStats.Money += moneyGain;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        --WaveSpawner.EnemiesAlive;
        Destroy(gameObject);
    }
}