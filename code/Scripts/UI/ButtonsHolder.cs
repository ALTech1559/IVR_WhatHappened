using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Monetization;

public class ButtonsHolder : MonoBehaviour
{
	[Header("GameObjects")]
	[SerializeField] private GameObject CallsPanel;
	[SerializeField] private GameObject MessagesPanel;
	[SerializeField] private GameObject TermuxPanel;
	[SerializeField] private GameObject MainTextTermux;
	[SerializeField] private GameObject ErrorTermux;
	[SerializeField] private GameObject PasswordPanel;
	[SerializeField] private GameObject LightControllerPaswwrodPanel;
	[SerializeField] private GameObject PurchasePanel;

	[Header("Others")]
	[SerializeField] private InputField PhoneInput;
	[SerializeField] private InputField PhonePasswordInput;
	[SerializeField] private AudioSource buttonClickSound;
	[SerializeField] private AudioSource lightControllerSound;
	[SerializeField] private GameObject SettingsPanel;

	private bool callsApp = false;
	private bool messagesApp = false;
	private bool termuxApp = false;
	private bool termuxCheck = false;


	[Header("Light")]

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

	[Header("HintGameobjects")]
	[SerializeField] private List<GameObject> hintGameObjects = new List<GameObject>();

	private bool openSettingsPanel = false;

	internal static event UnityAction goOnTheSecondFloor;
	internal static event UnityAction goOnTheFirstFloor;
	internal static event UnityAction closeLightControllerPanel;
	internal static event UnityAction joystickChangeStatement;
	internal static event UnityAction programmerSpeechDisable;
	internal static event UnityAction changePhoneStatement;
	internal static event UnityAction changeBookStatement;
	internal static event UnityAction lightStatementChange;

	public void OpenSettings()
	{
		ClickSound();
		openSettingsPanel = !openSettingsPanel;
		SettingsPanel.SetActive(openSettingsPanel);
	}

	public void Advertising()
	{
		ClickSound();
		if (Monetization.IsReady("rewardedVideo"))
		{
			ShowAdCallbacks options = new ShowAdCallbacks();
			options.finishCallback = HandleShowresult;
			ShowAdPlacementContent advert = Monetization.GetPlacementContent("rewardedVideo") as ShowAdPlacementContent;
			advert.Show(options);
		}
		else
		{
			PurchasePanel.SetActive(true);
		}
	}

	public void HandleShowresult(ShowResult result)
	{
		if (result == ShowResult.Finished)
		{
			int index = 0;
			string[] playerPrefs = { "CorridorKey", "LightController", "Lantern", "Battery", "Phone", "Termux", "AllowToStreet", "Trap" };
			foreach(string playerPrefsString in playerPrefs)
			{
				if (PlayerPrefs.HasKey(playerPrefsString) == false)
				{
					hintGameObjects[index].SetActive(true);
					hintGameObjects[index].GetComponent<HintController>().PlayHint();
					break;
				}
				index++;
			}
		}
	}

	public void MenuOpen()
	{
		ClickSound();
		SceneLoading.ChangeScene("Menu");
	}

	public void TermuxButtonCheck()
	{
		ClickSound();
		if (PhoneInput.text == "+790678938703")
		{
			MainTextTermux.SetActive(true);
			ErrorTermux.SetActive(false);
			termuxCheck = true;
			programmerSpeechDisable?.Invoke();
			lightStatementChange?.Invoke();
		}
		else
		{
			MainTextTermux.SetActive(false);
			ErrorTermux.SetActive(true);
		}
	}

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

	private void SwitchOffLight(string roomName, GameObject lightObject)
	{
		PlayerPrefs.SetInt(roomName, 0);
		lightObject.SetActive(true);
	}

	private void ButtonSwitch(GameObject lightButton)
	{
		lightButton.transform.Rotate(Vector3.forward, 180);
	}

	public void GoOnTheSecondFloor()
	{
		ClickSound();
		goOnTheSecondFloor?.Invoke();
	}

	public void GoOnTheFirstFloor()
	{
		ClickSound();
		goOnTheFirstFloor?.Invoke();
	}

	public void ExitInPhone()
	{
		if (PhonePasswordInput.text == "4559")
		{
			PasswordPanel.SetActive(false);
		}
	}

	public void SwitchThePhone()
	{
		ClickSound();
		changePhoneStatement?.Invoke();
	}

	public void SwitchCalls() 
	{
		SwitchApp(ref callsApp, CallsPanel);
	}

	public void SwitchTermux()
	{
		SwitchApp(ref termuxApp, TermuxPanel);
	}

	public void SwitchMessages()
	{
		SwitchApp(ref messagesApp, MessagesPanel);
	}  

	private void SwitchApp(ref bool appStatement, GameObject appButton)
	{
		ClickSound();
		appStatement = !appStatement;
		appButton.SetActive(appStatement);
	}

	public void OpenTheBook()
	{
		ClickSound();
		changeBookStatement?.Invoke();
		joystickChangeStatement?.Invoke();
	}

	public void ExitFirstMiniGame()
	{
		ClickSound();
		joystickChangeStatement?.Invoke();
		closeLightControllerPanel?.Invoke();
	}

	public void ExitlightControllerPassword()
	{
		ClickSound();
		LightControllerPaswwrodPanel.SetActive(false);
		joystickChangeStatement?.Invoke();
	}

	private void Start()
	{
		if (Monetization.isSupported)
		{
			Monetization.Initialize("3774419", false);
		}

		PlayerPrefs.SetInt("PantryLight", 0);
		PlayerPrefs.SetInt("CafeLight", 1);
		PlayerPrefs.SetInt("KitchenLight", 1);
	}

	private void ClickSound()
	{
		buttonClickSound.Play();
	}
}
