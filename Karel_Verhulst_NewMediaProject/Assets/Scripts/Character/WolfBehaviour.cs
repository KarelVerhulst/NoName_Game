using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBehaviour : BaseCharacterBehaviour
{
    [SerializeField]
    private GameObject _dragon = null;
    [SerializeField]
    private float _waitTime = 1;

    private float _time = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (this.GetComponentInParent<TransformBehaviour>().IsTransformAvailable && InputController.IsButtonXPressed() && !this.IsCharacterSplit && this.GetComponentInParent<HealthBehaviour>().Health > 0)
        {
            SetState(new TransformState(this, _dragon));
            this.GetComponentInParent<TransformBehaviour>().TransformAmount = 0;
        }

        bool newTriggerHeld = InputController.GetRightTrigger() > 0f;
        if (newTriggerHeld)
        {

            if (!this.GetComponentInParent<ManaBehaviour>().IsManaEmpty)
            {
                this.GetComponentInParent<ManaBehaviour>().TrySpendMana(_spendingAmountOfMana);

                _time -= Time.deltaTime;

                if (_time <= 0)
                {
                    Debug.Log("Shield is up");
                    _time = _waitTime;
                }

                
            }

        }
        else
        {
            this.GetComponentInParent<ManaBehaviour>().IsManaEmpty = false;
            this.GetComponentInParent<ManaBehaviour>().FillManaAmount();
        }
    }


}
