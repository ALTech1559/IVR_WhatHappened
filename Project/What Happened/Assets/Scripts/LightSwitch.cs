using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
	[SerializeField] private AudioSource lightControllerSound;

	[Header("Pantry")]
	[SerializeField] private GameObject Pantry;
	[SerializeField] private GameObject PantryButton;
	private bool pantry = false;

	[Header("Cafe")]
	[SerializeField] private GameObject Cafe;
	[SerializeField] private GameObject CafeButton;
	private bool cafe = true;

	[Header("Kitchen")]
	[SerializeField] private GameObject Kitchen;
	[SerializeField] private GameObject KitchenButton;
	private bool kitchen = true;

	public void LightInPantry()
	{
		lightControllerSound.Play();
		pantry = !pantry;
		if (pantry)
		{
			PlayerPrefs.SetInt("PantryLight", 1);
			Pantry.SetActive(false);
			kitchen = false;
			cafe = false;
			PlayerPrefs.SetInt("KitchenLight", 0);
			Kitchen.SetActive(true);

			if (KitchenButton.transform.rotation.z == 0)
			{
				KitchenButton.transform.Rotate(Vector3.forward, 180);
			}

			PlayerPrefs.SetInt("CafeLight", 0);
			Cafe.SetActive(true);

			if (CafeButton.transform.rotation.z == 0)
			{
				CafeButton.transform.Rotate(Vector3.forward, 180);
			}
		}
		else
		{
			SwitchOffLight("PantryLight", Pantry);
		}
		ButtonSwitch(PantryButton);
	}

	public void LightInKitchen()
	{
		lightControllerSound.Play();
		kitchen = !kitchen;
		if (kitchen)
		{
			PantryOperation(Kitchen, "KitchenLight");
		}
		else
		{
			SwitchOffLight("KitchenLight", Kitchen);
		}
		ButtonSwitch(KitchenButton);
	}

	public void LightInCafe()
	{
		lightControllerSound.Play();
		cafe = !cafe;
		if (cafe)
		{
			PantryOperation(Cafe, "CafeLight");
		}
		else
		{
			SwitchOffLight("CafeLight", Cafe);
		}
		ButtonSwitch(CafeButton);
	}

	private void SwitchOffLight(string roomName, GameObject lightObject)
	{
		PlayerPrefs.SetInt(roomName, 0);
		lightObject.SetActive(true);
	}

	private void ButtonSwitch(GameObject lightButton)
	{
		lightButton.transform.Rotate(Vector3.forward, 180);
	}

	private void PantryOperation(GameObject objectPanel, string playerPrefsName)
	{
		pantry = false;
		PlayerPrefs.SetInt("PantryLight", 0);
		Pantry.SetActive(true);

		if (PantryButton.transform.rotation.z == 0)
		{
			PantryButton.transform.Rotate(Vector3.forward, 180);
		}

		PlayerPrefs.SetInt(playerPrefsName, 1);
		objectPanel.SetActive(false);
	}
}
