using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHP : MonoBehaviour
{
    public float mobHP = 100;
    void DestroyGoblin()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mobHP <= 0)
        {
            DestroyGoblin();
        }
    }
}
