using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAIBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _destPoint;

    private NavMeshAgent _ghost;

    // Start is called before the first frame update
    void Start()
    {
        _ghost = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //_ghost.destination = _destPoint.position;
        _ghost.destination = GameObject.FindGameObjectWithTag("Respawn").transform.position;
    }
    
}
