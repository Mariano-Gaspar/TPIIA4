// MARIANO CODUTTI ALARCON
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public enum EnemyType
    {
        Ground,
        Air,
    }


    [SerializeField] private Transform hitPoint;
    public Transform TargetPoint => hitPoint;


    [Header("Enemy Type")]
    [SerializeField] private EnemyType enemyType;
    public EnemyType Type => enemyType;


    [Header("Health Settings")]
    [SerializeField] private float baseEnemyHealth = 100;
    private float enemyHealth;

    [SerializeField] private Image healthBar;


    [Header("Death Settings")]
    [SerializeField] private int deathValue = 20;
    [SerializeField] private GameObject deathEffect;

    private bool isDead = false;


    private void Start()
    {
        enemyHealth = baseEnemyHealth;
    }


    public void TakeDamage(float _damageAmount)
    {
        enemyHealth -= _damageAmount;
        healthBar.fillAmount = enemyHealth / baseEnemyHealth;

        if (enemyHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        PlayerStats.money += deathValue;
        PlayerStats.score_KillPoints += deathValue;
        WaveSpawner.enemiesAlive--;

        GameObject deathEffectGO = (GameObject)Instantiate(deathEffect, hitPoint.position, hitPoint.rotation);
        Destroy(deathEffectGO, 2f);

        Destroy(gameObject);
    }
}
