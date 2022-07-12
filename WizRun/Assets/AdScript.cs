using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdScript : MonoBehaviour
{

    private BannerView bannerView;

    [SerializeField] private string appID = "ca-app-pub-5119476635199805~4925517023";



    [SerializeField] private string bannerID = "ca-app-pub-5119476635199805/5472311933";

    private void Awake()
    {
        MobileAds.Initialize(appID);
    }

    public void showBanner()
    {
        this.RequestBanner();
    }







    private void RequestBanner()
    {
        bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }
}
