using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

internal class RoomsData : MonoBehaviour
{
    internal enum Names
    {
        stair1,
        corridor,
        cafe,
        kitchen,
        bedroom,
        bathroom,
        pantry,
        wordrop,
        stair2,
        balcony
    }

    [Header("Game objects")]
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject GoOnTheSecondFloor;
    [SerializeField] private GameObject GoOnTheFirstFloor;

    [Header("Lists")]
    private List<Room> _rooms = new List<Room>();
    private List<string> _names = new List<string>();
    [SerializeField] private List<Vector3> _cameraVectors = new List<Vector3>();
    [SerializeField] private List<float> _sizes = new List<float>();

    [Header("Audio")]
    [SerializeField] private AudioSource _doorSound;
    [SerializeField] private AudioSource _stairSound;

    private bool _can_go;
    internal static string _lastRoomName;
    internal static event UnityAction _transition;
    internal static event UnityAction changeStateOfMiniGame;
    internal static event UnityAction joystickStatement;

    private void Start()
    {
        PlayerPrefs.SetInt("CafeLight", 1);
        PlayerPrefs.SetInt("KitchenLight", 1);
        Initialization();
    }

    private void Initialization()
    {
        foreach (Names s in Enum.GetValues(typeof(Names)))
        {
            _names.Add(s.ToString());
        }

        for (int i = 0; i < _names.Count; ++i)
        {
            Room _room = new Room(_names[i], _cameraVectors[i], _sizes[i]);
            _rooms.Add(_room);
        }
    }

    internal void Movement(string roomName, bool isGoingOnTheNextFloor)
    {
        _can_go = true;
        roomName = Check(roomName);
        float currentSize = 0;
        Vector3 cameraPos = Vector3.zero;
        _lastRoomName = roomName;
        for (int i = 0; i < _names.Count; ++i)
        {
            if (roomName == _rooms[i].name)
            {
                cameraPos = _rooms[i].cameraPosition;
                currentSize = _rooms[i].cameraSize;
            }  
        }

        if (_can_go)
        {
            if (!isGoingOnTheNextFloor)
            {
                _doorSound.pitch = UnityEngine.Random.Range(0.9f, 1.6f);
                _doorSound.Play();
            }
            else
            {
                _stairSound.Play();
                StartCoroutine(StopStairSound());
                PlayerController.isGoingOnTheNextFloor = false;
                WalllsControll.isGoingOnTheNextFloor = false;
            }
            _transition?.Invoke();

            StartCoroutine(Transition(cameraPos, currentSize));
        }

    }

    private System.Collections.IEnumerator StopStairSound()
    {
        yield return new WaitForSeconds(0.7f);
        _stairSound.Stop();
    }

    private string Check(string roomName)
    {
        if (roomName == "corridor" && PlayerPrefs.GetInt("CorridorKey") != 1)
        {
            _can_go = false;
            roomName = "stair1";
        }

        if (roomName == "corridor" && PlayerPrefs.GetInt("CorridorKey") == 1 && PlayerPrefs.GetInt("CorridorGame") != 1)
        {
            //Player.GetComponent<PlayerController>().speed = 0;
            _can_go = false;
            roomName = "stair1";
            changeStateOfMiniGame?.Invoke();
            joystickStatement?.Invoke();
        }
        
        if (roomName == "pantry" && PlayerPrefs.GetInt("PantryLight") != 1)
        {
            _can_go = false;
            roomName = "bathroom";
        }

        if (roomName == "cafe" && PlayerPrefs.GetInt("CafeLight") != 1)
        {
            _can_go = false;
            roomName = "stair1";
        }

        if (roomName == "kitchen" && PlayerPrefs.GetInt("KitchenLight") != 1)
        {
            _can_go = false;
            roomName = "cafe";
        }

        GoOnTheSecondFloor.SetActive((roomName == "stair1"));  
        GoOnTheFirstFloor.SetActive((roomName == "stair2"));
        return roomName;
    }

    private IEnumerator Transition(Vector3 cameraPos, float currentSize)
    {
        yield return new WaitForSeconds(0.65f);
        Player.transform.position = new Vector3(cameraPos.x, Player.transform.position.y, Player.transform.position.z);
        MainCamera.transform.position = cameraPos;
        MainCamera.GetComponent<Camera>().orthographicSize = currentSize;
    }

    internal class Room
    {
        internal string name;
        internal Vector3 cameraPosition;
        internal float cameraSize;
        public Room(string Name, Vector3 cameraPos, float Size)
        {
            name = Name;
            cameraPosition = cameraPos;
            cameraSize = Size;
        }
    }
}


