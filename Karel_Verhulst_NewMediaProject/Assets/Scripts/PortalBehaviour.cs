﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    /*
     * still work in progress
     * when the character walks into a portal the character split in two
     */

    [SerializeField]
    private Transform _newPosition = null;
    [SerializeField]
    private Transform _ghostPosition = null;
    [SerializeField]
    private GameObject _dragonAI = null;
    [SerializeField]
    private GameObject _wolfAI = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log(_newPosition.position);

        if (other.GetComponent<WolfBehaviour>())
        {
            WolfBehaviour wolf = other.GetComponent<WolfBehaviour>();

            Instantiate(_dragonAI, _ghostPosition);
            wolf.SetState(new SplitState(wolf, _newPosition));

        }else if (other.GetComponent<DragonBehaviour>())
        {
            DragonBehaviour dragon = other.GetComponent<DragonBehaviour>();

            Instantiate(_wolfAI, _ghostPosition);
            dragon.SetState(new SplitState(dragon, _newPosition));
        }
    }
}
