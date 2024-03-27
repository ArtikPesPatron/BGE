using UnityEngine;

public class Aid : MonoBehaviour
{
    private float _hpheal = 50;

    private void OnTriggerEnter(Collider other)
    {
        var PlayerCheck = other.gameObject.GetComponent<PlayerHealth>();
        if(PlayerCheck != null)
        {
            PlayerCheck.AddHealth(_hpheal);
            Destroy(gameObject);
        }
    }
}
