using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSwitchStatue : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10;

    [SerializeField]
    private GameObject[] _statues = null;

    [SerializeField]
    private float _maxCountDownTimer = 1;

    private float _countDownTimer = 0;
    private int _index = 0;
    private int _oldIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        _countDownTimer = _maxCountDownTimer;
        _statues[_index].SetActive(true);
        _statues[_oldIndex].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RotateStatue();

        SwitchStatueAfterTime();
    }

    private void RotateStatue()
    {
        this.transform.Rotate(Vector3.up * _speed * Time.deltaTime);
    }

    private void SwitchStatueAfterTime()
    {
        _countDownTimer -= Time.deltaTime;

        if (_countDownTimer <= 0)
        {
            _oldIndex = _index;
            _index++;

            _index %= _statues.Length;
            _oldIndex %= _statues.Length;

            _statues[_index].SetActive(true);
            _statues[_oldIndex].SetActive(false);

            _countDownTimer = _maxCountDownTimer;
        }
    }
}
