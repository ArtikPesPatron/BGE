using UnityEngine;

public class Aid : MonoBehaviour
{
    private float HPheal = 50;

    private void OnTriggerEnter(Collider other)
    {
        var PlayerCheck = other.gameObject.GetComponent<PlayerHealth>();
        if(PlayerCheck != null)
        {
            PlayerCheck.AddHealth(HPheal);
            Destroy(gameObject);
        }
    }
}
