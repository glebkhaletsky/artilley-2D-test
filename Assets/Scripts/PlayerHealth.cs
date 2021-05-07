using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public Image HealthStatus;
    public int MaxHealth;
    public GameObject EnemyIndicator;
    public RoundManager RoundManager;
    public AudioSource Scream;

    private void Start()
    {
        HealthStatus.fillAmount = 1f;
        MaxHealth = Health;
    }
    public void TakeDamage(int damageValue)
    {
        Scream.Play();
        Health -= damageValue;
        HealthStatus.fillAmount -= (float)damageValue / (float)MaxHealth;
        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
    }

    public void RewardHealth()
    {
        Health =  Mathf.RoundToInt((float)MaxHealth / 2f);
        HealthStatus.fillAmount+= (float)Health / (float)MaxHealth;
    }

    public void Die()
    {
        RoundManager.PlayerDie();
    }
}
