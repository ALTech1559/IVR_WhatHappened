using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NumberP : MonoBehaviour, IPointerClickHandler
{
    private int _currentNumber = 0;
    private Text _text;
    [SerializeField] private List<Text> _numberPads = new List<Text>();
    [SerializeField] private GameObject LightController;
    private LightControllerHolder _lightController;
    private string _key = "2480";
    private void Start()
    {
        _lightController = LightController.GetComponent<LightControllerHolder>();
        _text = GetComponent<Text>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _currentNumber++;

        if (_currentNumber == 10)
        {
            _currentNumber = 0;
        }

        _text.text = _currentNumber.ToString();
        if ($"{_numberPads[0].text}{_numberPads[1].text}{_numberPads[2].text}{_numberPads[3].text}" == _key)
        {
            PlayerPrefs.SetString("LightController", "open");
            StartCoroutine(PanelSwitchOn());
        }
        
    }

    private IEnumerator PanelSwitchOn()
    {
        yield return new WaitForSeconds(1);
        _lightController.OpenPanel();
    }
}
