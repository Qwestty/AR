using nsDB;
using TMPro;
using UnityEngine;

public class EditUser : MonoBehaviour
{
    public static EditUser instance;

    [Header("UI")]
    [SerializeField] private TMP_InputField titleInputField;
    [SerializeField] private TMP_InputField descriptionInputField;


    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }

    public void Edit(string UserLogin, string UserName)
    {

        titleInputField.text = UserLogin;
        descriptionInputField.text = UserName;
    }

    public void SaveLab()
    {
        Nucleus.instance.EditUsers(titleInputField.text, descriptionInputField.text);
    }
}
