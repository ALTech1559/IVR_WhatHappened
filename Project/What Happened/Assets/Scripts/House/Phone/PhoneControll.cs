using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhoneControll : MonoBehaviour
{
	[SerializeField] private GameObject PhoneButton;
	[SerializeField] private GameObject Password;
	private GameObject Child;
	internal static event UnityAction _programmerSpeechAwake;

	private void Start()
	{
		//initialize components
		Child = transform.GetChild(0).gameObject;

		//activate object if key is 1
		if (PlayerPrefs.GetInt("PasswordActive") == 1)
		{
			Password.SetActive(true);
		}

		if (!(PlayerPrefs.GetInt("Lantern") == 1 && PlayerPrefs.GetInt("Battery") == 1))
		{
			Child.SetActive(false);
		}

		if (PlayerPrefs.GetInt("Phone") == 1)
		{
			PhoneButton.SetActive(true);
		}
	}

	private void OnEnable()
	{
		//subscribe on events
		CapboardTap._onClick += Click;
		BatteryTaker._onClick += ChildActivate;
	}

	private void OnDisable()
	{
		//unsubscribe on events
		CapboardTap._onClick -= Click;
		BatteryTaker._onClick -= ChildActivate;
	}

	private void ChildActivate()
	{
		Child.SetActive(true);
	}

	private void Click()
	{
		if (PlayerPrefs.GetInt("Lantern") == 1 && PlayerPrefs.GetInt("Battery") == 1)
		{
			//invoke event
			_programmerSpeechAwake?.Invoke();
			Password.SetActive(true);
			//set keys
			PlayerPrefs.SetInt("PasswordActive", 1);
			PlayerPrefs.SetInt("Phone", 1);
			gameObject.SetActive(true);
			//play animation
			GetComponent<Animator>().Play("PhoneAwake");
			PhoneButton.SetActive(true);
		}

	}
}
 