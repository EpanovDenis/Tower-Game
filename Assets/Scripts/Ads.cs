﻿using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class Ads : MonoBehaviour
{
    private string gameID = "4107273", type = "video";
    private bool testMode = true, needToStop;

    private Coroutine showAd;

    private static int countLoses;

    private void Start()
    {
        Advertisement.Initialize(gameID, testMode);

        countLoses++;
        if (countLoses % 3 == 0)
        {
            showAd = StartCoroutine(ShowAd());
        }        
    }
    private void Update()
    {
        if (needToStop)
        {
            needToStop = false;
            StopCoroutine(showAd);
        }
    }
    IEnumerator ShowAd()
    {
        while (true)
        {
            if (Advertisement.IsReady(type))
            {
                Advertisement.Show(type);
                needToStop = true;                
            }
            yield return new WaitForSeconds(1f);
        }
    }

}
