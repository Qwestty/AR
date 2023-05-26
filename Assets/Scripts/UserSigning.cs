using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using nsDB;


public class UserSigning : MonoBehaviour
{
    [Header("Registration")]
    [SerializeField] private TMP_InputField registrationNameField;
    [SerializeField] private TMP_InputField registrationPasswordField;
    [SerializeField] private TMP_InputField registrationEmailField;
    [SerializeField] private GameObject registrationNameFieldError;
    [SerializeField] private GameObject registrationPasswordFieldError;
    [SerializeField] private GameObject registrationEmailFieldError;
    [SerializeField] private Button item;

    [Header("Authorization")]
    [SerializeField] private TMP_InputField authorizeEmailField;
    [SerializeField] private TMP_InputField authorizePasswordField;

    [Header("UI")]
    [SerializeField] private GameObject entryMenu;
    [SerializeField] private GameObject registrationMenu;
    [SerializeField] private GameObject cabinetMenu;


    private Nucleus _nucleus;

    private void Start()
    {
        _nucleus = Nucleus.instance;

        CheckUserLogin();
    }

    public void AuthorizeUser()
    {
        if (_nucleus.AuthorizeUser(authorizeEmailField.text, authorizePasswordField.text))
        {
            SignIn();

        } if (_nucleus.AuthorizeAdmin(authorizeEmailField.text, authorizePasswordField.text))
        {
            SignInAdmin();
        }
        else
        {
                Debug.LogError("Введите логин!");
                registrationNameFieldError.SetActive(true);
                item.enabled = false;
                Debug.LogError("Введите пароль!");
                item.enabled = false;
                registrationPasswordFieldError.SetActive(true);
        }
    }
    public void LoadScene(int sceneid)
    {
        SceneManager.LoadScene(sceneid);
    }
    public void RegisterUser()
    {
        if(String.IsNullOrEmpty(registrationNameField.text)){
            Debug.LogError("Введите логин!");
            registrationNameFieldError.SetActive(true);
            item.enabled = false;
        }if(String.IsNullOrEmpty(registrationPasswordField.text)){
            Debug.LogError("Введите пароль!");
            item.enabled = false;
            registrationPasswordFieldError.SetActive(true);
        }if(String.IsNullOrEmpty(registrationEmailField.text)){
            Debug.LogError("Введите ФИО!");
            item.enabled = false;
            registrationEmailFieldError.SetActive(true);
        } else {
                if (_nucleus.CreateUser(registrationNameField.text, registrationPasswordField.text, registrationEmailField.text))
                {
                      LoadScene(2);
                }
                else
                {
                    Debug.LogError("Registration Error!");
                }
        }
    }
    public void SignOut()
    {
        Nucleus.currentUserId = -1;
    }

    private void SignIn()
    {
        LoadScene(3);
    }
    private void SignInAdmin()
    {
        LoadScene(11);
    }

    private void CheckUserLogin()
    {
        if (Nucleus.currentUserId == -1) return;

        SignIn();
    }
}