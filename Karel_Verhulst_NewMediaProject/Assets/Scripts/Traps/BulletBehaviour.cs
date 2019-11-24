using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    [SerializeField]
    private float _projectileSpeed = 10;
    [SerializeField]
    private int _attackDamage = 1;

    public float maxSize;
    public float growFactor;
    public float waitTime;



    public Vector3 ShootPostion { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScaleProjectile());
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().AddForce(ShootPostion * _projectileSpeed);
        //this.GetComponent<Rigidbody>().velocity = ShootPostion * _projectileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<HealthBehaviour>())
        {
            HealthBehaviour hb = other.GetComponentInParent<HealthBehaviour>();

            if (other.GetComponent<DragonBehaviour>())
            {
                DecreaseHealth(hb);
            }
            else if (other.GetComponent<WolfBehaviour>())
            {
                if (!other.GetComponent<WolfBehaviour>().IsShieldActive)
                {
                    DecreaseHealth(hb);
                }
            }
        }
        
        if (other.tag != "Enemy" && other.tag != "TrapCheck" && other.tag != "EnemyShield" && !other.GetComponent<DragonBullet>())
        {
            Destroy(this.gameObject);
        }
        
    }

    private void DecreaseHealth(HealthBehaviour hb)
    {
        if (hb.Health > 0)
        {
            hb.CharacterTakeDamage(_attackDamage);
            hb.ChangeHealth(hb.Health);
        }
    }

    private IEnumerator ScaleProjectile()
    {
        float timer = 0;

        while (true) // this could also be a condition indicating "alive or dead"
        {
            // we scale all axis, so they will have the same value, 
            // so we can work with a float instead of comparing vectors
            while (maxSize > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }
            // reset the timer

            yield return new WaitForSeconds(waitTime);

            timer = 0;
            while (1 < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }

            timer = 0;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
