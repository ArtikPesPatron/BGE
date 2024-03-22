using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    public List<Transform> patrolPoints;
    public PlayerController player;
    private bool _playerVisible;
    public float viewAngle;
    public float damage = 30;
    private PlayerHealth _playerHealth;

    private void AttackUpdate()
    {
        if (_playerVisible == true)
        {
            if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _playerHealth.DealDamage(damage * Time.deltaTime);
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
        playerVisible();
        AttackUpdate();
    }
}
