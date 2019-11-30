using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : BaseBullet
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<HealthBehaviour>())
        {
            HealthBehaviour hb = other.GetComponentInParent<HealthBehaviour>();

            if (other.GetComponent<DragonBehaviour>())
            {
                DecreaseHealth(hb);
            }
            else if (other.GetComponent<WolfBehaviour>())
            {
                if (!other.GetComponent<WolfBehaviour>().IsShieldActive)
                {
                    DecreaseHealth(hb);
                }
            }
        }
        
        if (other.tag != "Enemy" && other.tag != "TrapCheck" && other.tag != "EnemyShield" && !other.GetComponent<DragonBullet>())
        {
            Destroy(this.gameObject);
        }
        
    }

    private void DecreaseHealth(HealthBehaviour hb)
    {
        if (hb.Health > 0)
        {
            hb.CharacterTakeDamage(_attackDamage);
            hb.ChangeHealth(hb.Health);
        }
    }
}
