using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStreetController : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    private Vector3 _moveVector;

    [Header("GameObjects")]
    [SerializeField] private GameObject Joistick;
    [SerializeField] private GameObject Rope;
    [SerializeField] private GameObject TrapHelp;

    [Header("Effects")]
    [SerializeField] private ParticleSystem Particals;

    [Header("Audio")]
    [SerializeField] private AudioSource stepSound;

    private StreetJoistick _joystick;
    private Animator _animator;
    private CharacterController _charterController;
    private bool _helpIsShown = false;

    void Start()
    {
        //initialization of components
        _charterController = GetComponent<CharacterController>();
        _joystick = Joistick.GetComponent<StreetJoistick>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        //playermoving by joystick
        CharterMove();
        //panel activation if player in special zone
        if (transform.position.x < 4.67f && transform.position.z < -31 && PlayerPrefs.GetInt("Trap") != 1)
        {
            if (_helpIsShown == false)
            {
                TrapHelp.SetActive(true);
                _helpIsShown = true;
            }  
            Rope.SetActive(true);
        }

    }
    private void CharterMove()
    {
        //initialization of moving vector
        _moveVector.z = _joystick.Vertical() * _speedMove;
        _moveVector.x = _joystick.Horizontal() * _speedMove;
        //start animation
        if (_moveVector.z != 0 && _moveVector.x != 0)
        {
            if (!stepSound.isPlaying)
            {
                stepSound.Play();
            }
            _animator.SetBool("isRunning", true);
            Particals.Play();
        }
        else
        {
            stepSound.Stop();
            _animator.SetBool("isRunning", false);
            Particals.Stop();
        }
        //give rotation to player
        if (Vector3.Angle(Vector3.forward, _moveVector) > 0 || Vector3.Angle(Vector3.forward, _moveVector) == 0.0f)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, -_moveVector, _speedMove * 100, 0f);

            transform.rotation = Quaternion.LookRotation(direct);
        }
        //player move
        _charterController.Move(_moveVector * Time.fixedDeltaTime);
    }

}
