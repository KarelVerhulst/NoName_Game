using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : BaseBullet
{
    /*
     * child -> enemie bullet
     */

    //[SerializeField]
    //private LayerMask _mask;

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

        DestroyBullet(other);
    }

    private void DecreaseHealth(HealthBehaviour hb)
    {
        if (hb.Health > 0)
        {
            hb.CharacterTakeDamage(_attackDamage);
            hb.ChangeHealth(hb.Health);
        }
    }

    private void DestroyBullet(Collider other)
    {
        //change this to layermask
        if (other.tag != "Enemy" && other.tag != "TrapCheck" && other.tag != "EnemyShield" && !other.GetComponent<DragonBullet>() && !other.GetComponent<WolfBullet>())
        {
            Destroy(this.gameObject);
        }

        //if (_mask != (_mask | (1 << other.gameObject.layer)))
        //{
        //    Destroy(this.gameObject);
        //}
    }
}
