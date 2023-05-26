using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


public class ShowDiv1 : MonoBehaviour
    {
    [SerializeField] private GameObject div;
    [SerializeField] private GameObject div1;


    public void onClick()
        {
            div.SetActive(false);
            div1.SetActive(false);
        }
}
