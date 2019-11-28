using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCurrentObjectIsTrigger : MonoBehaviour
{
    [Range(0, 5)]
    [SerializeField]
    private int _orderPosition = 0;

    public bool OneTime { get; set; }
    public bool IsDragonBullet { get; set; }

    void Start()
    {
        OneTime = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.GetComponentInParent<DragonBullet>())
        {
            IsDragonBullet = true;

            this.GetComponentInParent<LightObjectBehaviour>().Light.SetActive(true);
            this.GetComponentInParent<LightObjectBehaviour>().IsLightOn = true;


            if (!OneTime)
            {
                this.GetComponentInParent<LightItInTheRightOrderBehaviour>().ListOfPositionItHit.Add(_orderPosition);
                OneTime = true;
            }
        }
    }

    
}
