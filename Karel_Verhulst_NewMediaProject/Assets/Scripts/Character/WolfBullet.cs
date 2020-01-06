using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBullet : BaseBullet
{
    /*
     * child class -> wolf bullet
     */
    private void OnTriggerEnter(Collider other)
    {
        //change this with layermask but if i put a layermask on a object the object is invisible
        if (other.tag != "Player" && other.tag != "Enemy" && other.tag != "Bolt" && !other.GetComponent<BulletBehaviour>() && other.tag != "WolfShield")
        {
            Destroy(this.gameObject);
        }
    }
}
