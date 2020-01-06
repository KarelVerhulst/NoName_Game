using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBehaviour : BaseCharacterBehaviour
{
    /*
     * child class -> wolf
     */

    [SerializeField]
    private GameObject _dragon = null;
    [SerializeField]
    private GameObject _shield = null;
    
    public bool IsShieldActive { get; set; }

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
        }

        PressMagicTrigger();
    }

    private void PressMagicTrigger()
    {
        bool newTriggerHeld = InputController.GetRightTrigger() > 0f;
        if (newTriggerHeld && this.GetComponentInParent<HealthBehaviour>().Health > 0)
        {
            WolfMagicAttack();
        }
        else
        {
            _shield.SetActive(false);

            this.GetComponentInParent<ManaBehaviour>().IsManaEmpty = false;
            this.GetComponentInParent<ManaBehaviour>().FillManaAmount();
        }
    }

    public void WolfMagicAttack()
    {
        if (!this.GetComponentInParent<ManaBehaviour>().IsManaEmpty)
        {
            this.GetComponentInParent<ManaBehaviour>().TrySpendMana(_spendingAmountOfMana);

            //_shield.SetActive(true);
            IsShieldActive = true;

        }
        else
        {
            //_shield.SetActive(false);
            IsShieldActive = false;
        }

        _shield.SetActive(IsShieldActive);
    }
}
