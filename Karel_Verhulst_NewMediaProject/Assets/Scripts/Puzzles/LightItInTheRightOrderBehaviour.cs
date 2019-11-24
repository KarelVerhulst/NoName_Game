﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightItInTheRightOrderBehaviour : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _listOfEnemies = new List<GameObject>();
    [SerializeField]
    private Transform _puzzleViewCamera = null;
    
    private List<int> _correctOrderPosition = new List<int>();
    
    private float _timer = 5;
    private Transform _oldCameraPosition = null;

    private bool _oneTime = false;

    public bool IsPuzzleFinished { get; set; }
    public List<int> ListOfPositionItHit = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _listOfEnemies.Count; i++)
        {
            _correctOrderPosition.Add(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ListOfPositionItHit.Count == _correctOrderPosition.Count)
        {
            CheckIfTheOrderIsCorrect();
        }
    }

    private void CheckIfTheOrderIsCorrect()
    {
        if (CheckArrays(ListOfPositionItHit, _correctOrderPosition))
        {
            MoveCameraToFinishPosition();
        }
        else
        {
            ResetOrderPuzzle();
        }
    }

    private void MoveCameraToFinishPosition()
    {
        IsPuzzleFinished = true;

        if (_timer <= 0)
        {
            if (!_oneTime)
            {
                _oneTime = true;
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, _oldCameraPosition.position, Time.deltaTime * 50);
            }
        }
        else
        {
            _timer -= Time.deltaTime;
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, _puzzleViewCamera.position, Time.deltaTime * 50);
        }
    }

    private void ResetOrderPuzzle()
    {
        ListOfPositionItHit.Clear();

        for (int i = 0; i < _listOfEnemies.Count; i++)
        {
            _listOfEnemies[i].GetComponentInChildren<LightObjectBehaviour>().Light.SetActive(false);
            _listOfEnemies[i].GetComponentInChildren<CheckCurrentObjectIsTrigger>().OneTime = false;
        }
    }

    private bool CheckArrays(List<int> array1, List<int> array2)
    {
        if (array1.Count != array2.Count) return false;
        for (int i = 0; i < array1.Count; i++)
            if (array1[i] != array2[i]) return false;
        return true;
    }
}
