using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


public class ExitThird : MonoBehaviour
    {
    [SerializeField] private GameObject registrationEmailFieldError;
    [SerializeField] private Button item;

        public void onClick()
        {
            registrationEmailFieldError.SetActive(false);
            item.enabled = true;
        }
}
