using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform SpawnPosition;
    public float BulletSpeed;
    public Aim Aim;
    public AudioSource ShotSound;
    public virtual void Shot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, SpawnPosition.position, SpawnPosition.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = SpawnPosition.forward * BulletSpeed;
        ShotSound.Play();

    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }


}
