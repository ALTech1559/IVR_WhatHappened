using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class PurchaseController : MonoBehaviour
{
    public HintController HintController
    {
        get => default;
        set
        {
        }
    }

    public HintController HintController1
    {
        get => default;
        set
        {
        }
    }

    [SerializeField] private GameObject PurchasePanel;

    [Header("Hint gameobjects")]
    [SerializeField] private List<GameObject> hintGameObjects;

    private void Start()
    {
        //initialize monetization
        if (Monetization.isSupported)
        {
            Monetization.Initialize("3774419", false);
        }
    }

    internal void PlayPurchase()
    {
        if (Monetization.IsReady("rewardedVideo"))
        {
            //start loading video
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
            string[] playerPrefs = { "CorridorKey", "LightController", "Lantern",
                "Battery", "Phone", "Termux", "AllowToStreet", "Trap" };
            //find next hint
            foreach (string playerPrefsString in playerPrefs)
            {
                if (!PlayerPrefs.HasKey(playerPrefsString))
                {
                    print(index);
                    hintGameObjects[index].SetActive(true);
                    hintGameObjects[index].GetComponent<HintController>().PlayHint();
                    break;
                }
                index++;
            }
        }
    }
}
