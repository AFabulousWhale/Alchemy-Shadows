using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyList", menuName = "ScriptableObjects/EnemyList", order = 1)]
public class EnemyList : ScriptableObject
{
    public List<EnemySO> enemies;
}
