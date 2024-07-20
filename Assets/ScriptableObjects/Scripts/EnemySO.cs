using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemySO : ScriptableObject
{
    public GameObject enemyPrefab;
    public float maxHealth;
    public WeaponSO weapon;

    //can add enums for different attacks etc - once these are more polished and decided
}
