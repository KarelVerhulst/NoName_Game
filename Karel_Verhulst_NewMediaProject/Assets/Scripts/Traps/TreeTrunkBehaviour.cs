using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTrunkBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector3 _minScale = Vector3.zero;
    [SerializeField]
    private Vector3 _maxScale = Vector3.zero;
    [SerializeField]
    private bool _repeatable = false;
    [SerializeField]
    private float _speed = 2f;
    [SerializeField]
    private float _duration = 5f;
    [SerializeField]
    private float _startingWait = 0;
    [SerializeField]
    private float _waitAfterStartingScaling = 0;
    [SerializeField]
    private float _waitAfterEndingScaling = 0;

    private bool _isAtTheEnd = false;
    
    IEnumerator Start()
    {
        
        _minScale = this.transform.localScale;

        yield return new WaitForSeconds(_startingWait);

        while (_repeatable)
        {
            yield return ScaleOverTime(_minScale, _maxScale, _duration);
        }
    }



    private IEnumerator ScaleOverTime(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * _speed;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;

            if (this.transform.localScale == b)
            {
                yield return new WaitForSeconds(_waitAfterEndingScaling);
                _isAtTheEnd = true;
            }
            

            if (_isAtTheEnd)
            {
                
                this.transform.localScale = Vector3.Lerp(b, a, i);
            }
            else
            {
                this.transform.localScale = Vector3.Lerp(a, b, i);
            }

            if (this.transform.localScale == a)
            {
                yield return new WaitForSeconds(_waitAfterStartingScaling);
                _isAtTheEnd = false;
            }


            yield return null;
        }

    }
}
