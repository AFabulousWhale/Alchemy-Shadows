using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponPrefab;
    public float damageMax;
    public float damageMin;
    public float speed;
    public GameObject bullet;
    public WeaponType weaponType;
}

public enum WeaponType
{
    ranged,
    melee
}
