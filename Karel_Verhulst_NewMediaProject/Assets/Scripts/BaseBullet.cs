using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    /*
     * the parent class of the bullets
     */

    [SerializeField]
    private float _projectileSpeed = 10;
    [SerializeField]
    protected int _attackDamage = 1;

    [SerializeField]
    private float _maxSize = 0;
    [SerializeField]
    private float _growFactor = 0;
    [SerializeField]
    private float _waitTime = 0;

    public Vector3 ShootPostion { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //had the idea to scale the bullets but doesn't look good with the VFX bullets
        //StartCoroutine(ScaleProjectile());
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().AddForce(ShootPostion * _projectileSpeed);
    }

    private IEnumerator ScaleProjectile()
    {
        float timer = 0;

        while (true) // this could also be a condition indicating "alive or dead"
        {
            // we scale all axis, so they will have the same value, 
            // so we can work with a float instead of comparing vectors
            while (_maxSize > transform.localScale.x)
            {
                timer += Time.deltaTime;
                this.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * _growFactor;
                yield return null;
            }
            // reset the timer

            yield return new WaitForSeconds(_waitTime);

            timer = 0;
            while (1 < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * _growFactor;
                yield return null;
            }

            timer = 0;
            yield return new WaitForSeconds(_waitTime);
        }
    }
}
