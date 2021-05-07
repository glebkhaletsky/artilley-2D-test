using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    //public Text RewardsStatusText;
    //public Text Plushki;

    public PlayerHealth PlayerHealth;
    public RoundManager RoundManager;
    public GameObject LoseSceen;
    void Start()
    {
        IronSource.Agent.init("f73db391", IronSourceAdUnits.REWARDED_VIDEO, IronSourceAdUnits.INTERSTITIAL, IronSourceAdUnits.OFFERWALL, IronSourceAdUnits.BANNER);
        //Invoke("InitBanner", 3);
        IronSourceEvents.onRewardedVideoAdOpenedEvent += RewardedVideoAdOpenedEvent;
    }

    /*private void Update()
    {
        RewardsStatusText.text = IronSource.Agent.isRewardedVideoAvailable().ToString();
    }*/

    //init banner

    /*void InitBanner()
    {
        IronSource.Agent.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.TOP);
        RewardsStatusText.text = IronSource.Agent.isRewardedVideoAvailable().ToString();
    }*/

    /*public void LoadFullScreen()
    {
        IronSource.Agent.loadInterstitial();
    }*/

    /*public void ShowFullScreen()
    {
        IronSource.Agent.showInterstitial();
    }*/

    public void ShowReward()
    {
        IronSource.Agent.showRewardedVideo();
        
    }
    void RewardedVideoAdOpenedEvent()
    {
        PlayerHealth.RewardHealth();
        RoundManager.NewRound();
        LoseSceen.SetActive(false);
    }
}
