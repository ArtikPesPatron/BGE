using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyGoblin : MonoBehaviour
{
    public Enemy enemy;
    public void AttackEvent1()
    {
        enemy.Attack1();
    }
    public void AttackEvent2()
    {
        enemy.Attack2();
    }
}
