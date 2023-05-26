using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


public class ExitFirst : MonoBehaviour
    {
    [SerializeField] private GameObject registrationNameFieldError;
    [SerializeField] private Button item;

        public void onClick()
        {
            registrationNameFieldError.SetActive(false);
            item.enabled = true;
        }
}
