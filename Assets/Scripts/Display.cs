using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using nsDB;

public class Display : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI userLoginTitle;
    [SerializeField] private TextMeshProUGUI userNameTitle;
    [SerializeField] private TextMeshProUGUI ticketsPrice;
    [SerializeField] private TextMeshProUGUI taskNamePrefab;
    [SerializeField] private TextMeshProUGUI taskDescriptionPrefab;
    [SerializeField] private Transform taskContainer;

    private Nucleus _nucleus;

    private void Start()

    {
        _nucleus = Nucleus.instance;
        display();

    }

    private void display()
    {
        string userLogin = _nucleus.GetUserlogin();
        string userPass = _nucleus.GetUserPassword();
        userLoginTitle.SetText(userLogin);
        userNameTitle.SetText(userPass);
    }
}