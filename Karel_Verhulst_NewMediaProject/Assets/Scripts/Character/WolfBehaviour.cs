using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBehaviour : BaseCharacterBehaviour
{
    [SerializeField]
    private GameObject _dragon = null;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (InputController.IsButtonXPressed() && !this.IsCharacterSplit && this.GetComponentInParent<HealthBehaviour>().Health > 0)
        {
            SetState(new TransformState(this, _dragon));
        }
    }


}
