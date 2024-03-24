using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage = 100;
    public float maxSize = 5;
    public float speed = 3;
    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * speed;

        if(transform.localScale.y > maxSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var Player = other.gameObject.GetComponent<PlayerHealth>();
        if(Player != null)
        {
            Player.DealDamage(damage);
        }

        var Enemy = other.gameObject.GetComponent<Enemy>();
        if(Enemy != null)
        {
            Enemy.DealDamage(damage);
        }
    }
}
