using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using nsDB;

public class Show : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI taskNameoneTitle;
    [SerializeField] private TextMeshProUGUI taskNametwoTitle;
    [SerializeField] private TextMeshProUGUI taskNamethreeTitle;


    private Nucleus _nucleus;

    private void Start()
    {
        _nucleus = Nucleus.instance;
        GetAllTickets();
    }

    private void GetAllTickets()
    {
        string ticketName = _nucleus.GetTicketsName();
        taskNameoneTitle.SetText(ticketName);
        string ticketNametwo = _nucleus.GetTicketsNametwo();
        taskNametwoTitle.SetText(ticketNametwo);
        string ticketsNamethree = _nucleus.GetTicketsNamethree();
        taskNamethreeTitle.SetText(ticketsNamethree);
    }
}