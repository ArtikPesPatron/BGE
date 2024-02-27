using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public float Speed;
    public float lifetime;
    public float damage = 20;

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<MobHP>();
        if(enemyHealth != null)
        {
            enemyHealth.mobHP -= damage;
        }
    }
    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    private void GoForward()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }

    void Start()
    {
        
    }
    private void Update()
    {
        Invoke("DestroyGameObject", lifetime);
    }

    void FixedUpdate()
    {
        GoForward();
    }
    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyGameObject();
    }
}
