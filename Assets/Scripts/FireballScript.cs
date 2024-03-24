using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public float damage = 20;
    public float lifetime;
    public float Speed;

    private void DamageEnemy(Collision collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.DealDamage(damage);
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

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyGameObject();
    }
    void FixedUpdate()
    {
        GoForward();
    }
    private void Update()
    {
        Invoke("DestroyGameObject", lifetime);
    }
}
