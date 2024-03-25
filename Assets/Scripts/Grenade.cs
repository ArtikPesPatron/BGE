using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public float delay = 3;
    public float damage = 30;
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", delay);
    }

    private void Explosion()
    {
        Destroy(gameObject);
        var explosion = Instantiate(ExplosionPrefab);
        explosion.transform.position = transform.position;
        explosion.GetComponent<Explosion>().damage = damage;
    }
}
