using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCurrentObjectIsTrigger : MonoBehaviour
{
    /*
     * check if the torchlight is hit or not
     * if a bullet hit this trigger the position is added to the list
     */
    [Range(0, 5)]
    [SerializeField]
    private int _orderPosition = 0;

    public bool OneTime { get; set; }
    public bool IsDragonBullet { get; set; }
    public bool IsWolfBullet { get; set; }

    void Start()
    {
        OneTime = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        switch (this.GetComponentInParent<LightObjectBehaviour>().CurrentTorchlightType)
        {
            case LightObjectBehaviour.TypeOfTorchlight.Advanced:
                AddPositionToList(other, true);
                break;
            case LightObjectBehaviour.TypeOfTorchlight.OnlyDragon:
            case LightObjectBehaviour.TypeOfTorchlight.OnlyWolf:
            case LightObjectBehaviour.TypeOfTorchlight.Normal:
                AddPositionToList(other);
                break;
            default:
                break;
        }
    }

    private void AddPositionToList(Collider other, bool isAdvanced = false)
    {
        
        if (isAdvanced)
        {
            if (other.GetComponentInParent<DragonBullet>())
            {
                IsDragonBullet = true;
            }
                
            if (other.GetComponentInParent<WolfBullet>())
            {
                
                IsWolfBullet = true;

                if (!OneTime)
                {

                    this.GetComponentInParent<LightItInTheRightOrderBehaviour>().ListOfPositionItHit.Add(_orderPosition);
                    OneTime = true;
                }
            }
        }
        else
        {
            if (other.GetComponentInParent<DragonBullet>() || other.GetComponentInParent<WolfBullet>())
            {
                IsDragonBullet = other.GetComponentInParent<DragonBullet>();
                IsWolfBullet = other.GetComponentInParent<WolfBullet>();
                
                if (!OneTime)
                {

                    this.GetComponentInParent<LightItInTheRightOrderBehaviour>().ListOfPositionItHit.Add(_orderPosition);
                    OneTime = true;
                }
            }
        }
    }
}
