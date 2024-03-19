﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    public float damage;
    public List<Transform> patrolPoints;
    public PlayerController player;
    private bool _playerVisible;
    public float viewAngle;
    private PlayerHealth playerHealth;

    private void AttackUpdate()
    {
        if(_playerVisible == true && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            playerHealth.DealDamage(damage * Time.deltaTime);
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
        playerHealth = GetComponent<PlayerHealth>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
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
