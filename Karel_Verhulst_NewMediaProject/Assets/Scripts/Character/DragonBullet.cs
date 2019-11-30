﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBullet : BaseBullet
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Enemy" && !other.GetComponent<BulletBehaviour>())
        {
            Destroy(this.gameObject);
        }
    }
}
