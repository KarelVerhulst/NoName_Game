using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCurrentObjectIsTrigger : MonoBehaviour
{
    [SerializeField]
    private bool _IAmFirstInOrder = false;

    public bool IsHit { get; set; }
    public bool CanIHit { get; set; }

    void Start()
    {
        IsHit = false;
        CanIHit = _IAmFirstInOrder;
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
