using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject GunEnemy;
    public GameObject EnemyBullet;
    public Transform SpawnEnemyBullet;
    public float BulletSpeed;
    public Transform Player;
    public bool AimDone;
    public AudioSource ShotSound;
    public void EnemyGunActivate()
    {
        GunEnemy.SetActive(true);
    }

    public void EnemyGunDiactivate()
    {
        GunEnemy.SetActive(false);
    }

    void Update()
    {
        Vector3 toAim = Player.position - transform.position;
        Quaternion target = Quaternion.LookRotation(toAim);

        transform.rotation = Quaternion.LerpUnclamped(transform.rotation, target, Time.deltaTime *10f);
        if(transform.rotation == target)
        {
            AimDone = true;
        }
    }


    public void Shot()
    {
        GameObject newBullet = Instantiate(EnemyBullet, SpawnEnemyBullet.position, SpawnEnemyBullet.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = SpawnEnemyBullet.forward * BulletSpeed;
        ShotSound.Play();
    }

}
