using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBehaviour : BaseCharacterBehaviour
{
    [SerializeField]
    private GameObject _wolf = null;


    public Transform _shootPosition = null;
    public GameObject _projectile = null;

    private float time = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
        if (InputController.IsButtonXPressed() && !this.IsCharacterSplit && this.GetComponentInParent<HealthBehaviour>().Health > 0)
        {
            SetState(new TransformState(this, _wolf));
        }

        if (InputController.GetRightTrigger() != 0)
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                GameObject bullet = Instantiate(_projectile, _shootPosition.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<DragonBullet>().ShootPostion = _shootPosition.forward;

                SetState(new MagicAttackState(this));

                time = 1;
            }
            
        }

        if (InputController.GetLeftJoystick() != Vector3.zero)
        {
            SetState(new WalkState(this));
        }
    }
}
