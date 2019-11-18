using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCurrentObjectIsTrigger : MonoBehaviour
{
    public bool IsHit { get; set; }
    public bool CanIHit { get; set; }

    void Start()
    {
        IsHit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(CanIHit);
        if (CanIHit)
        {
            IsHit = true;
        }
        else
        {
            IsHit = false;
        }
    }

    
}
