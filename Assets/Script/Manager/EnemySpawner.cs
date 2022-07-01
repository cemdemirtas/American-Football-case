using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
public class EnemySpawner : EnemyMovement
{
    EnemyMovement _enemymovement;
    Quaternion quaternion;
    GameObject Opponent;

    void OpponentSpawn(EnemyMovement enemyMovement)
    {
        _enemymovement = enemyMovement;
        _enemymovement.OnCollisionEnter(_enemymovement.gameObject.GetComponent<Collision>());
    }
}
