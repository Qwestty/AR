using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


public class ExitSecond : MonoBehaviour
    {
    [SerializeField] private GameObject registrationPasswordFieldError;
    [SerializeField] private Button item;

        public void onClick()
        {
            registrationPasswordFieldError.SetActive(false);
            item.enabled = true;
        }
}
