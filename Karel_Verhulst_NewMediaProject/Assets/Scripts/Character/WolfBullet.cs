using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBullet : BaseBullet
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Enemy" && !other.GetComponent<BulletBehaviour>() && other.tag != "WolfShield")
        {
            Destroy(this.gameObject);
        }
    }
}
