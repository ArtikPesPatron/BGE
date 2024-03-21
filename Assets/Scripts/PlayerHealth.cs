using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float HP = 100;
    private float maxHP;
    public RectTransform valueRectTransform;

    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(HP / maxHP, 1);
    }

    private void PlayerDeath()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
    }
    public void DealDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            PlayerDeath();
        }

        DrawHealthBar();
    }
    void Start()
    {
        maxHP = HP;
        DrawHealthBar();
    }

    
    void Update()
    {
        
    }
}
