/*
 * 
 * Copyright (c) 2015 All Rights Reserved, VERGOSOFT LLC
 * Title: VundaBall
 * Author: Scott Zastrow
 * iOS Version: 1.2
 * 
 * 
 */
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using System;
using System.Collections;

public class IAPManager : MonoBehaviour, IStoreListener
{
    private IStoreController controller;
    private IExtensionProvider extensions;
    public GameObject iapNoticePanel;
    public GameObject disablePanel;
    public GameObject settingsPanel;

    public Toggle firstToggle;
    public Toggle secondToggle;
    public Text pOne;
    public Text pTwo;

    private string[] theProducts = new string[2];

    void Awake()
    {
        IAPBuild();
    }
    void Start()
    {
        disablePanel.transform.SetAsFirstSibling();
        iapNoticePanel.transform.SetAsFirstSibling();
        iapNoticePanel.SetActive(false);
    }

    void IAPBuild()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        try
        {
            builder.AddProduct("vb011", ProductType.Consumable, new IDs
        {
            {"Buy +1 Lives", MacAppStore.Name}
        }
                );
            builder.AddProduct("vb013", ProductType.Consumable, new IDs
        {
            { "Buy +3 Lives", MacAppStore.Name}
        }
                );
        }
        catch
        {
            print("Builder Failed to Add Products.");
        }
        try
        {
            UnityPurchasing.Initialize(this, builder);
        }
        catch
        {
            print("Builder Failed to Initialize Products.");
        }
    }

    public void BuyLives()
    {
        //StartCoroutine(pauseASec());
        
        if (firstToggle.isOn == true)
            controller.InitiatePurchase("vb011");
        else if (secondToggle.isOn == true)
            controller.InitiatePurchase("vb013");

        Time.timeScale = 0;
    }

    /// <summary>
    /// Called when Unity IAP is ready to make purchases.
    /// </summary>
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
        this.extensions = extensions;

        foreach (var product in controller.products.all)
        {
            if (product.availableToPurchase)
            {
                Debug.Log(product.metadata.localizedTitle);
                Debug.Log(product.metadata.localizedDescription);
                Debug.Log(product.metadata.localizedPriceString);
            }
        }
        //print("FT1 is " + controller.products.WithID("FT1").metadata.localizedTitle);
        try
        {
            pOne.text = "Buy +1 Lives " + controller.products.WithID("vb011").metadata.localizedPriceString;
            pTwo.text = "Buy +3 Lives " + controller.products.WithID("vb013").metadata.localizedPriceString;
        }
        catch
        {
            pOne.text = "+1 Lives $0.99";
            pTwo.text = "+3 Lives $2.99";
        }
        //print("**********************************Unity is Ready to Make a Purchase*****************************");
    }

    /// <summary>
    /// Called when Unity IAP encounters an unrecoverable initialization error.
    ///
    /// Note that this will not be called if Internet is unavailable; Unity IAP
    /// will attempt initialization until it becomes available.
    /// </summary>
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        //print("Initialization Error! Unity IAP encounters an unrecoverable initialization error.");
        //theStatus.text = DateTime.Now.ToString("h:mm:ss tt");
        print("Reason for Error: " + error);
        disablePanel.transform.SetAsFirstSibling();
        iapNoticePanel.transform.SetAsFirstSibling();
        iapNoticePanel.SetActive(false);
        if (settingsPanel.activeInHierarchy)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        
    }

    /// <summary>
    /// Called when a purchase completes.
    ///
    /// May be called at any time after OnInitialized().
    /// </summary>
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        if (e.purchasedProduct.definition.id == "vb011")
        {
            VHealth.lives += 1;
            fileManager.addToXML();
        }
        else if (e.purchasedProduct.definition.id == "vb013")
        {
            VHealth.lives += 3;
            fileManager.addToXML();
        }
        //iapNoticePanel.SetActive(false);
        //iapNoticePanel.transform.SetAsFirstSibling();
        StartCoroutine(waitForIAP());
        disablePanel.transform.SetAsFirstSibling();
        //iapNoticePanel.SetActive(false);
        //iapNoticePanel.transform.SetAsFirstSibling();
        if (settingsPanel.activeInHierarchy)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        //Debug.Log("Purchase OK: " + e.purchasedProduct.definition.id);
        //Debug.Log("Receipt: " + e.purchasedProduct.receipt);
        return PurchaseProcessingResult.Complete;
    }

    /// <summary>
    /// Called when a purchase fails.
    /// </summary>
    public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
    {
        disablePanel.transform.SetAsFirstSibling();
        iapNoticePanel.transform.SetAsFirstSibling();
        iapNoticePanel.SetActive(false);

        if (settingsPanel.activeInHierarchy)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        

        if (p == PurchaseFailureReason.PurchasingUnavailable)
        {
            // IAP may be disabled in device settings.
        }
        print("Purchase Failed.");
    }
    IEnumerator waitForIAP()
    {
        iapNoticePanel.transform.SetAsFirstSibling();
        iapNoticePanel.SetActive(false);
        yield return new WaitForSeconds(10f);
        if (settingsPanel.activeInHierarchy)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void IAPNo()
    {
        PlayerPrefs.SetString("IAP", "NoIAP");
    }
    public void IAPYes()
    {
        PlayerPrefs.SetString("IAP", "YesIAP");
    }


}
