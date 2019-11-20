using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightItInTheRightOrderBehaviour : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _listOfEnemies = new List<GameObject>();
    [SerializeField]
    private Transform _puzzleViewCamera = null;

    private int _index = 0;
    private List<bool> _isHitList = new List<bool>();
    private List<bool> _trueList = new List<bool>();

    private bool test;

    private float _timer = 5;
    private Transform _oldCameraPosition = null;

    // Start is called before the first frame update
    void Start()
    {
        //first one in the list you can hit it
        _listOfEnemies[0].GetComponentInChildren<CheckCurrentObjectIsTrigger>().CanIHit = true;

        for (int i = 0; i < _listOfEnemies.Count; i++)
        {
            _trueList.Add(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_index != _listOfEnemies.Count);
        if (_index != _listOfEnemies.Count)
        {
            test = _listOfEnemies[_index].GetComponentInChildren<CheckCurrentObjectIsTrigger>().IsHit;
            
            if (test)
            {
                
                _isHitList.Add(test);
                _index++;
                //Debug.Log(_index);
                if (_index != _listOfEnemies.Count)
                {
                    _oldCameraPosition = Camera.main.transform;
                    _listOfEnemies[_index].GetComponentInChildren<CheckCurrentObjectIsTrigger>().CanIHit = true;
                }

                
            }
        }

        //if all the enemies are true you defeat them all in the right order !!
        if (CheckArrays(_isHitList, _trueList))
        {
            if (_timer <= 0)
            {
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, _oldCameraPosition.position, Time.deltaTime * 50);
            }
            else
            {
                _timer -= Time.deltaTime;
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, _puzzleViewCamera.position, Time.deltaTime * 50);
            }
            //Debug.Log("Correct order Do Something");
            
        }
        

    }

    private bool CheckArrays(List<bool> array1, List<bool> array2)
    {
        if (array1.Count != array2.Count) return false;
        for (int i = 0; i < array1.Count; i++)
            if (array1[i] != array2[i]) return false;
        return true;
    }
}
