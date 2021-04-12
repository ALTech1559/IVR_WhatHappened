using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private Image J;
    private Animator _animator;
    private Rigidbody _rigidbody;
    private float _moveSpeed;

    [Header("Parametrs")]
    [SerializeField] internal float _speed;

    [Header("GameObjects")]
    [SerializeField] private GameObject EyesLookingRight;
    [SerializeField] private GameObject Joystick;
    [SerializeField] private GameObject data;
    [SerializeField] private GameObject LeftLantern;
    [SerializeField] private GameObject RightLantern;

    internal static bool isGoingOnTheNextFloor = false;

    [Header("Audio")]
    [SerializeField] private AudioSource stepSound;

    private bool _way;

    private void Start()
    {
        J.rectTransform.anchoredPosition = new Vector3 (0,0,0);
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (Joystick.activeInHierarchy == false)
        {
            _moveSpeed = 0f;
        }

        if (J.rectTransform.anchoredPosition.x < 0)
        {
            _way = false;
            _moveSpeed = -_speed;
        }

        if (J.rectTransform.anchoredPosition.x > 0)
        {
            _way = true;
            _moveSpeed = _speed;
        }


        if (J.rectTransform.anchoredPosition.x == 0)
        {
            stepSound.Stop();
            _animator.SetBool("isRunning", false);
            _moveSpeed = 0f;
        }
        else
        {
            if (stepSound.isPlaying == false)
            {
                stepSound.Play();
            }
            _animator.SetBool("isRunning", true);
        }

        LeftLantern.SetActive(!Light.lightInHouse && !_way);
        RightLantern.SetActive(!Light.lightInHouse && _way);
        EyesLookingRight.SetActive(_way);

        _rigidbody.velocity = new Vector2(_moveSpeed, _speed);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("lastPositionX", transform.position.x);
        PlayerPrefs.SetFloat("lastPositionY", transform.position.y);
    }

    private void OnEnable()
    {
        ButtonsHolder.goOnTheSecondFloor += GoOnTheSecondFloor;
        ButtonsHolder.goOnTheFirstFloor += GoOnTheFirstFloor;
    }

    private void OnDisable()
    {
        ButtonsHolder.goOnTheSecondFloor -= GoOnTheSecondFloor;
        ButtonsHolder.goOnTheFirstFloor -= GoOnTheFirstFloor;
    }

    private void GoOnTheSecondFloor()
    {
        isGoingOnTheNextFloor = true;
        StartCoroutine(TransitionRoom("stair2", 36.86f));

    }

    private void GoOnTheFirstFloor()
    {
        isGoingOnTheNextFloor = true;
        StartCoroutine(TransitionRoom("stair1", -10.83f));

    }

    private IEnumerator TransitionRoom(string roomName, float positionY)
    {
        data.GetComponent<RoomsData>().Movement(roomName, isGoingOnTheNextFloor );
        yield return new WaitForSeconds(0.65f);
        transform.position = new Vector3(transform.position.x, positionY, transform.position.z);
        isGoingOnTheNextFloor = false;
    }
}
