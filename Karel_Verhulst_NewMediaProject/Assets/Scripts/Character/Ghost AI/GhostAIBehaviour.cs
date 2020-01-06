using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAIBehaviour : MonoBehaviour
{
    /*
     * right know I don't use this script because it's still a work in progress
     * but this will be the AI behaviour were I add more scripts (nodes) to let my ghost character do some actions
     */

    [SerializeField]
    private Transform _destPoint;

    private NavMeshAgent _ghost;

    void Start()
    {
        _ghost = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //_ghost.destination = _destPoint.position;
        _ghost.destination = GameObject.FindGameObjectWithTag("Respawn").transform.position;
    }
    
}
