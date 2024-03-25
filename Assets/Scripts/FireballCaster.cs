using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public FireballScript fireball;
    public Transform armTransform;
    public float damage = 10;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var fire = Instantiate(fireball, armTransform.position, armTransform.rotation);
            fire.damage = damage;
        }
    }
}
