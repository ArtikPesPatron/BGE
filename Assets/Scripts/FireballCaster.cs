using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public FireballScript fireball;
    public Transform armTransform;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fireball, armTransform.position, armTransform.rotation);
        }
    }
}
