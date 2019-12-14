using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObjectBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _shootObject = null;
    [SerializeField]
    private Transform projectilePosition = null;
    [SerializeField]
    private GameObject projectile = null;
    [SerializeField]
    private float _maxTimer = 1;
    [SerializeField]
    private float _advancedMaxTimer = 1;

    [SerializeField]
    private GameObject _shield = null;

    [SerializeField]
    private GameObject _light = null;

    /*
     * Normal -> torchlight shoot bullets to the player, player can hit it with wolf or dragon
     * Advanced -> torchlight shoot NOTHING, FIRST player has to shoot with the dragon, then torchlight shoot back and then you have to deflect it with the wolf
     * OnlyDragon -> torchlight shoots to the player BUT only the dragon can turn on the light 
     * OnlyWolf -> torchlight shoots to the player BUT only the wolf can turn on the light
     */
    public enum TypeOfTorchlight { Normal, Advanced, OnlyDragon, OnlyWolf }

    [SerializeField]
    private TypeOfTorchlight _chooseTypeOfTorchlight = TypeOfTorchlight.Normal;

    public GameObject Light
    {
        get { return _light; }
        set { _light = value; }
    }

    public bool IsLightOn { get; set; }
    public TypeOfTorchlight CurrentTorchlightType { get; set; }
    public int PhaseIndex {get;set;}
    
    private float _timer;
    private bool _isPuzzleFixed = false;
    private bool _isDragonBullet = false;
    private bool _isWolfBullet = false;

    private void Start()
    {
        _timer = _maxTimer;

        CurrentTorchlightType = _chooseTypeOfTorchlight;
        PhaseIndex = 0;
        _shield.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        _isPuzzleFixed = this.GetComponentInParent<LightItInTheRightOrderBehaviour>().IsPuzzleFinished;
        _isDragonBullet = this.GetComponentInChildren<CheckCurrentObjectIsTrigger>().IsDragonBullet;
        _isWolfBullet = this.GetComponentInChildren<CheckCurrentObjectIsTrigger>().IsWolfBullet;

        if (other.TryGetComponent<BaseCharacterBehaviour>(out BaseCharacterBehaviour character))
        {
            LookAtPlayer(character.transform);

            SetCorrectTypeOfTorchlight(other); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<BaseCharacterBehaviour>(out BaseCharacterBehaviour character))
        {
            if (_chooseTypeOfTorchlight != TypeOfTorchlight.Normal)
            {
                UseShieldWhenPlaying(false);
            }
            
            if (_chooseTypeOfTorchlight == TypeOfTorchlight.Advanced)
            {
                this.GetComponentInChildren<CheckCurrentObjectIsTrigger>().IsDragonBullet = false;
                this.GetComponentInChildren<CheckCurrentObjectIsTrigger>().IsWolfBullet = false;
            }
        }
        
    }

    private void LookAtPlayer(Transform character)
    {
        _shootObject.LookAt(character);
        //_shootObject.eulerAngles = new Vector3(0, _shootObject.transform.eulerAngles.y, 0);
        _shootObject.eulerAngles = new Vector3(-90, 0, _shootObject.transform.eulerAngles.y);
    }

    private void ShootObject(bool isAdvanced = false)
    {
        
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            GameObject bullet = Instantiate(projectile, projectilePosition.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<BulletBehaviour>().ShootPostion = projectilePosition.forward;

            if (isAdvanced)
            {
                _timer = _advancedMaxTimer;
            }
            else
            {
                _timer = _maxTimer;
            }
        }
    }

    private void SetCorrectTypeOfTorchlight(Collider character)
    {
        switch (_chooseTypeOfTorchlight)
        {
            case TypeOfTorchlight.Normal:
                if (!IsLightOn)
                {
                    ShootObject();
                    if (_isDragonBullet || _isWolfBullet)
                    {
                        SetLightOn();
                    }
                }
                
                break;
            case TypeOfTorchlight.Advanced:
                AdvancedTorchlightPuzzle();
                break;
            case TypeOfTorchlight.OnlyDragon:
                if (!IsLightOn)
                {
                    ShootObject();
                    UseShieldWhenPlaying(character.TryGetComponent<WolfBehaviour>(out WolfBehaviour wolf));
                    if (_isDragonBullet)
                    {
                        SetLightOn();
                    }
                }
                
                break;
            case TypeOfTorchlight.OnlyWolf:
                if (!IsLightOn)
                {
                    ShootObject();
                    UseShieldWhenPlaying(character.TryGetComponent<DragonBehaviour>(out DragonBehaviour dragon));

                    if (_isWolfBullet)
                    {
                        SetLightOn();
                    }
                }
                
                break;
            default:
                break;
        }
    }

    private void UseShieldWhenPlaying(bool isWrongCharacter)
    {
        if (isWrongCharacter)
        {
            _shield.SetActive(true);
        }
        else
        {
            _shield.SetActive(false);
        }
    }

    private void AdvancedTorchlightPuzzle()
    {
        //do nothing unless the dragon shoot at it then shoot back if the wolf reflect back then light is on.
        switch (PhaseIndex)
        {
            case 0:
                CheckIfDragonAttack();
                break;
            case 1:
                ShootObject(true);
                CheckIfWolfAttack();
                break;
            case 2:
                SetLightOn();
                break;
            default:
                break;
        }
    }

    private void CheckIfDragonAttack()
    {
        if (_isDragonBullet)
        {
            PhaseIndex++;
        }
    }

    private void CheckIfWolfAttack()
    {
        if (_isWolfBullet)
        {
            PhaseIndex++;
        }
    }

    private void SetLightOn()
    {
        //this.GetComponent<LightObjectBehaviour>().Light.SetActive(true);
        this.GetComponent<LightObjectBehaviour>().IsLightOn = true;
    }
}
