using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightItInTheRightOrderBehaviour : MonoBehaviour
{
    /*
     * control if the player hit the enemies in the right order
     * if not reset everything and play the failsound
     * if it is correct the camera moved to a position in the world so the player see that the gate is opening and that a puzzle piece is showing
     */
    [SerializeField]
    private Animation _gateAnimation = null;
    [SerializeField]
    private Animation _puzzleAnimation = null;
    [SerializeField]
    private List<GameObject> _listOfEnemies = new List<GameObject>();
    [SerializeField]
    private Transform _puzzleViewCamera = null;

    [SerializeField]
    private BaseCamera _camera = null;

    private AudioSource _failSound = null;
    
    private List<int> _correctOrderPosition = new List<int>();
    
    private float _timer = 5;
    
    public bool IsPuzzleFinished { get; set; }
    public List<int> ListOfPositionItHit = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        _failSound = this.GetComponent<AudioSource>();

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
            _failSound.Play();
            ResetOrderPuzzle();
        }
    }

    private void MoveCameraToFinishPosition()
    {
        IsPuzzleFinished = true;

        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            _gateAnimation.Play("SpikesDoorAnimation");
            _puzzleAnimation.Play("PuzzleAnimation");

            _camera._target = null;
            Camera.main.transform.position = _puzzleViewCamera.position;

        }
        else
        {
            _camera._target = GameObject.FindGameObjectWithTag("Player").transform;
        }

    }

    private void ResetOrderPuzzle()
    {
        ListOfPositionItHit.Clear();

        for (int i = 0; i < _listOfEnemies.Count; i++)
        {
            _listOfEnemies[i].GetComponentInChildren<LightObjectBehaviour>().Light.SetActive(false);
            _listOfEnemies[i].GetComponentInChildren<LightObjectBehaviour>().IsLightOn = false;
            _listOfEnemies[i].GetComponentInChildren<LightObjectBehaviour>().PhaseIndex = 0;
            _listOfEnemies[i].GetComponentInChildren<CheckCurrentObjectIsTrigger>().OneTime = false;
            _listOfEnemies[i].GetComponentInChildren<CheckCurrentObjectIsTrigger>().IsDragonBullet = false;
            _listOfEnemies[i].GetComponentInChildren<CheckCurrentObjectIsTrigger>().IsWolfBullet = false;
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
