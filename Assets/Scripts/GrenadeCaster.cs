using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody grenadePrefab;
    public Transform grenadeSource;
    public float damage = 30;
    public float force = 10;

    private void grenadeThrow()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = grenadeSource.position;
            grenade.GetComponent<Rigidbody>().AddForce(grenadeSource.forward * force);
            grenade.GetComponent<Grenade>().damage = damage;
        }
    }
    void Update()
    {
        grenadeThrow();
    }
}
