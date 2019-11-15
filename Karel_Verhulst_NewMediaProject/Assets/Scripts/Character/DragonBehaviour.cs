using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBehaviour : BaseCharacterBehaviour
{
    [SerializeField]
    private GameObject _wolf = null;

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
    }
}
