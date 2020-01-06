using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthGateBehaviour : MonoBehaviour
{
    /*
     * use animation to open the mouth of the model
     */

    [SerializeField]
    private Animation _mouthOpenAnimation = null;

    [SerializeField]
    private bool _isDragon = false;
    [SerializeField]
    private bool _isWolf = false;

    private bool _isCharacterInTheTrigger = false;

    private const string OPENWOLF = "Open Wolf Mouth";
    private const string CLOSEWOLF = "Close Wolf Mouth";
    private const string OPENDRAGON = "Open Dragon Mouth";
    private const string CLOSEDRAGON = "Close Dragon Mouth";
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WolfBehaviour>() && _isWolf)
        {
            _isCharacterInTheTrigger = true;
            PlayMouthAnimation(OPENWOLF);
        }

        if (other.GetComponent<DragonBehaviour>() && _isDragon)
        {
            _isCharacterInTheTrigger = true;
            PlayMouthAnimation(OPENDRAGON);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (_isCharacterInTheTrigger && (other.GetComponent<WolfBehaviour>() || other.GetComponent<DragonBehaviour>()))
        {
            if (_isDragon)
            {
                PlayMouthAnimation(CLOSEDRAGON);
            }

            if (_isWolf)
            {
                PlayMouthAnimation(CLOSEWOLF);
            }

            _isCharacterInTheTrigger = false; 
        }
    }

    private void PlayMouthAnimation(string animatieName)
    {
        _mouthOpenAnimation.Play(animatieName);
    }
}
