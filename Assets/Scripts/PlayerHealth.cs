using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float maxHP;
    private float rnd;

    public RectTransform valueRectTransform;
    public GameObject gameOverScreen;
    public GameObject gameplayUI;
    public Animator animator;
    public float HP = 100;
    public Enemy enemy;

    public void AddHealth(float amount)
    {
        HP += amount;
        HP = Mathf.Clamp(HP, 0, maxHP);
        DrawHealthBar();

    }
    private void RandomValue()
    {
        rnd = Random.Range(1, 3);
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(HP / maxHP, 1);
    }

    private void PlayerDeath()
    {
        if(rnd == 1)
        {
            animator.SetTrigger("Death1");
        }
        else
        {
            animator.SetTrigger("Death2");
        }
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        gameOverScreen.GetComponent<Animator>().SetTrigger("ShowScreen");
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
            enemy.GetComponent<Enemy>().PlayerDeath = true;
        }

        DrawHealthBar();
    }
    void Start()
    {
        maxHP = HP;
        DrawHealthBar();
    }

    private void Update()
    {
        RandomValue();
    }
}
