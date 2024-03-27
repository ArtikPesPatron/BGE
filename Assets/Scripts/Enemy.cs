using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private PlayerProgress _playerExp;
    private NavMeshAgent _navMeshAgent;
    private PlayerHealth _playerHealth;
    private bool _playerVisible;
    private float _rnd;

    public List<Transform> patrolPoints;
    public GameObject _visibilityText;
    public PlayerController player;
    public float EnemyDamage1 = 20;
    public float EnemyDamage2 = 10;
    public float EnemyDamage3 = 50;
    public float mobHP = 100;
    public float ExpAdd = 50;
    public Animator animator;
    public float viewAngle;
    public void Attack1()
    {
        _playerHealth.DealDamage(EnemyDamage1);
    }
    public void Attack2()
    {
        _playerHealth.DealDamage(EnemyDamage2);
    }
    private void Death()
    {
        GetComponent<Enemy>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        animator.SetTrigger("Death");
        _playerExp.AddExperience(ExpAdd);
        GetComponent<NavMeshAgent>().enabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        var damageTaken = collision.gameObject.GetComponent<FireballScript>();
        if(damageTaken != null)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
    public void DealDamage(float damage)
    {
        mobHP -= damage;
        if(mobHP <= 0)
        {
            Death();
        }
        else
        {
            _rnd = Random.Range(1, 3);
            if(_rnd == 1)
            {
                animator.SetTrigger("hit");
            }
            else
            {
                animator.SetTrigger("hit2");
            }
        }
    }
    private void AttackUpdate()
    {
        if (_playerVisible == true)
        {
            if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    private void playerVisible()
    {
        if (_playerVisible == true)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
    private void VisibilityCheck()
    {
        var direction = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _playerVisible = true;
                }
                else
                {
                    _playerVisible = false;
                }
            }
        }
    }
    private void PatrolUpdatePoint()
    {
        if (_playerVisible == false)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void ComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
        _playerExp = player.GetComponent<PlayerProgress>();
    }
    // Methods

    void Start()
    {
        ComponentLinks();
        PickNewPatrolPoint();
    }

    void Update()
    {
        PatrolUpdatePoint();
        VisibilityCheck();
        VisibilityText();
        playerVisible();
        AttackUpdate();
    }
}
