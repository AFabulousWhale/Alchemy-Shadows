using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDamage: MonoBehaviour
{
    public void Damage(float amountToDamage, GameObject attacker, GameObject objectHit)
    {
        if(objectHit != attacker) //if not hit self
        {
            Entity entity = objectHit.GetComponent<Entity>();
            
            if(entity) //if object has health
            {
                entity.Damage(amountToDamage);
            }
        }
    }
}
