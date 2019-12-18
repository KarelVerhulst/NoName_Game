using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTrunkBehaviour2 : MonoBehaviour
{
    /*
     * https://answers.unity.com/questions/29751/gradually-moving-an-object-up-to-speed-rather-then.html
     */

    [SerializeField]
    private Transform[] Waypoints = null;
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private float _secondsToWait = 1;
    [SerializeField]
    private bool _isStartAtLeft = false;

    [SerializeField]
    private Transform _respawnPostion = null;

    private int _index;

    // Start is called before the first frame update
    void Start()
    {
        if (_isStartAtLeft)
        {
            _index = 0;
        }
        else
        {
            _index = 1;
        }

        StartCoroutine(MoveTreeBetweenWaypoints());
    }
    
    IEnumerator MoveTreeBetweenWaypoints()
    {
        while (true)
        {
            if (Vector3.Distance(this.transform.position, Waypoints[_index].position) <= _speed * Time.deltaTime)
            {
                
                yield return new WaitForSeconds(_secondsToWait);
                UpdateIndex();
            }

            this.transform.position = Vector3.MoveTowards(this.transform.position, Waypoints[_index].transform.position, _speed * Time.deltaTime);
   

            yield return null;
        }
    }

    private void UpdateIndex()
    {
        ++_index;
        _index %= Waypoints.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BaseCharacterBehaviour character))
        {
            character.GetComponentInParent<HealthBehaviour>().CharacterTakeDamage(3);
            character.GetComponentInParent<HealthBehaviour>().RespawnPoint = _respawnPostion;
        }
    }
}
