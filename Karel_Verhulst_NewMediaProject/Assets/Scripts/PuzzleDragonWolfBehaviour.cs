using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDragonWolfBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BaseCharacterBehaviour>(out BaseCharacterBehaviour character))
        {
            Destroy(this.gameObject);
        }
    }
}
