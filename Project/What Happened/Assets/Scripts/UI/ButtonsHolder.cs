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

	[Header("Others")]
	[SerializeField] private InputField PhoneInput;
	[SerializeField] private InputField PhonePasswordInput;
	[SerializeField] private AudioSource buttonClickSound;
	[SerializeField] private GameObject SettingsPanel;

	private bool callsApp = false;
	private bool messagesApp = false;
	private bool termuxApp = false;
	private bool termuxCheck = false;

	private bool openSettingsPanel = false;

	internal static event UnityAction goOnTheSecondFloor;
	internal static event UnityAction goOnTheFirstFloor;
	internal static event UnityAction closeLightControllerPanel;
	internal static event UnityAction joystickChangeStatement;
	internal static event UnityAction programmerSpeechDisable;
	internal static event UnityAction changePhoneStatement;
	internal static event UnityAction changeBookStatement;
	internal static event UnityAction lightStatementChange;

	[SerializeField] private PurchaseController purchaseController;

	public BlockHolder BlockHolder
	{
		get => default;
		set
		{
		}
	}

	public PurchaseController PurchaseController
	{
		get => default;
		set
		{
		}
	}

	//functions for click on buttons

	public void OpenSettings()
	{
		ClickSound();
		openSettingsPanel = !openSettingsPanel;
		SettingsPanel.SetActive(openSettingsPanel);
	}

	public void Advertising()
	{
		ClickSound();
		purchaseController.PlayPurchase();
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
		//set keys
		PlayerPrefs.SetInt("PantryLight", 0);
		PlayerPrefs.SetInt("CafeLight", 1);
		PlayerPrefs.SetInt("KitchenLight", 1);
	}

	private void ClickSound()
	{
		buttonClickSound.Play();
	}

    public PurchaseController PurchaseController1
    {
        get => default;
        set
        {
        }
    }
}
