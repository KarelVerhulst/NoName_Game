using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndBehaviour : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<BaseCharacterBehaviour>(out BaseCharacterBehaviour character))
        {
            this.GetComponent<FadeInOut>().FadeIn();
        }
    }

    
}
