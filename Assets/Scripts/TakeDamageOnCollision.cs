using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public AudioSource EnemyScream;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<Bullet>())
            {
                EnemyHealth.TakeDamage(collision.rigidbody.GetComponent<Bullet>().DamageValue);
                EnemyScream.Play();
            }
        }
    }
}
