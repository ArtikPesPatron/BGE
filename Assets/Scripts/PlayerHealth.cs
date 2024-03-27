using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float _maxHP;
    private float _rnd;

    public RectTransform valueRectTransform;
    public GameObject gameOverScreen;
    public GameObject gameplayUI;
    public Animator animator;
    public float HP = 100;
    public Enemy enemy;

    public void AddHealth(float amount)
    {
        HP += amount;
        HP = Mathf.Clamp(HP, 0, _maxHP);
        DrawHealthBar();

    }
    private void RandomValue()
    {
        _rnd = Random.Range(1, 3);
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(HP / _maxHP, 1);
    }

    private void PlayerDeath()
    {
        if(_rnd == 1)
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
        }

        DrawHealthBar();
    }
    void Start()
    {
        _maxHP = HP;
        DrawHealthBar();
    }

    private void Update()
    {
        RandomValue();
    }
}
