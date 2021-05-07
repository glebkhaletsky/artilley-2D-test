using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int Health;
    public Image HealthStatus;
    private int _maxHealth;
    public GameObject EnemyIndicator;

    public RoundManager RoundManager;

    private void Start()
    {
        HealthStatus.fillAmount = 1f;
        _maxHealth = Health;
    }
    public void TakeDamage(int damageValue)
    {
        Health -= damageValue;
        HealthStatus.fillAmount -=  (float)damageValue / (float)_maxHealth;
        if (Health <= 0)
        {
            Die();
        }
        
    }

    void Die()
    {
       
        Destroy(gameObject);
        Destroy(EnemyIndicator.gameObject);
        RoundManager.EnemyDie();
    }
}
