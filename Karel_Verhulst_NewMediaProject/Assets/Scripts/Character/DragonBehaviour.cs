using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBehaviour : BaseCharacterBehaviour
{
    [SerializeField]
    private GameObject _wolf = null;
    [SerializeField]
    private float _waitTime = 1;
    
    [SerializeField]
    private Transform _shootPosition = null;
    [SerializeField]
    private GameObject _projectile = null;

    private float _time = 0;

    private bool oldTriggerHeld;

    // Start is called before the first frame update
    void Start()
    {
        _time = _waitTime;
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
        if (this.GetComponentInParent<TransformBehaviour>().IsTransformAvailable && InputController.IsButtonXPressed() && !this.IsCharacterSplit && this.GetComponentInParent<HealthBehaviour>().Health > 0)
        {
            SetState(new TransformState(this, _wolf));
        }
        
        bool newTriggerHeld = InputController.GetRightTrigger() > 0f;
        if (newTriggerHeld && this.GetComponentInParent<HealthBehaviour>().Health > 0)
        {
            
            if (!this.GetComponentInParent<ManaBehaviour>().IsManaEmpty)
            {
                this.GetComponentInParent<ManaBehaviour>().TrySpendMana(_spendingAmountOfMana);

                _time -= Time.deltaTime;

                if (_time <= 0)
                {

                    GameObject bullet = Instantiate(_projectile, _shootPosition.position, Quaternion.identity) as GameObject;
                    bullet.GetComponent<DragonBullet>().ShootPostion = _shootPosition.forward;

                    SetState(new MagicAttackState(this));

                    _time = _waitTime;
                }
            }
            
        }
        else
        {
            this.GetComponentInParent<ManaBehaviour>().IsManaEmpty = false;
            this.GetComponentInParent<ManaBehaviour>().FillManaAmount();
        }

        //if (!oldTriggerHeld && newTriggerHeld) {
        //    GameObject bullet = Instantiate(_projectile, _shootPosition.position, Quaternion.identity) as GameObject;
        //    bullet.GetComponent<DragonBullet>().ShootPostion = _shootPosition.forward;
            
        //    SetState(new MagicAttackState(this));

        //}

        //oldTriggerHeld = newTriggerHeld;



    }
}
