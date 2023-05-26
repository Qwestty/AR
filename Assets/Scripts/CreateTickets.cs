using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateTickets : MonoBehaviour
{
    [Header("Add")]
    [SerializeField] private TMP_InputField ticketPrice;
    [SerializeField] private TMP_InputField ticketTime;
    [SerializeField] private TMP_InputField ticketData;
    [SerializeField] private TMP_InputField ticketDeparture;
    [SerializeField] private TMP_InputField ticketArrival;
    [SerializeField] private TMP_InputField ticketPlace;
    [SerializeField] private TMP_InputField ticketVoyage;
    [SerializeField] private TMP_InputField ticketLandingUp;

    private Nucleus _nucleus;

    private void Start()
    {

        _nucleus = Nucleus.instance;
    }

    public void AddTickets()
    {
        if(String.IsNullOrEmpty(ticketPrice.text)){
            Debug.LogError("Введите логин!");
        } else {
                if (_nucleus.CreateTickets(ticketPrice.text, ticketTime.text, ticketData.text, ticketDeparture.text, ticketArrival.text, ticketPlace.text, ticketVoyage.text, ticketLandingUp.text))
                {
                    Debug.LogError("ok!");
                }
                else
                {
                    Debug.LogError("Add Error!");
                }
        }
    }
}