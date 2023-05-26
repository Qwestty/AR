using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


public class ShowDiv : MonoBehaviour
    {
    [SerializeField] private GameObject div;


        public void onClick()
        {
            div.SetActive(true);
        }
}
