using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _newPosition;
    [SerializeField]
    private Transform _ghostPosition;
    [SerializeField]
    private GameObject _dragonAI;
    [SerializeField]
    private GameObject _wolfAI;
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
