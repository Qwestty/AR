using System;
using System.Collections.Generic;
using System.Globalization;
using nsDB;
using SQLite4Unity3d;
using UnityEngine;


public class Nucleus : MonoBehaviour
{
    public static Nucleus instance;

    public static int currentUserId = -1;
    public static int currentTicketId = 1;
    public static int currentTicketIdtwo = 2;
    public static string tableName = "tickets";
    int sum;

    private SQLiteConnection _db = DB.database.getConn();

    private Nucleus _nucleus;

    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;

        DontDestroyOnLoad(this);
    }

    public bool CreateUser(string userName, string userPassword, string userEmail)
    {
        try
        {
            DateTime date = DateTime.Now;
            User newUser = new User();
            newUser.usr_login = userName;
            newUser.usr_password = userPassword;
            newUser.usr_name = userEmail;


            _db.Insert(newUser);
            currentUserId = newUser.usr_id;
            return true;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return false;
        }
    }
    public bool CreateTickets(string ticketPrice, string ticketTime, string ticketData, string ticketDeparture, string ticketArrival,
    string ticketPlace, string ticketVoyage, string ticketLandingUp)
    {
        try
        {
            Tickets newTickets = new Tickets();
            newTickets.tickets_price = ticketPrice;
            newTickets.tickets_departure_time = ticketTime;
            newTickets.tickets_data = ticketData;
            newTickets.city_id_departure = ticketDeparture;
            newTickets.city_id_arrival = ticketArrival;
            newTickets.tickets_place = ticketPlace;
            newTickets.tickets_voyage = ticketVoyage;
            newTickets.tickets_landing_up = ticketLandingUp;

            _db.Insert(newTickets);
            currentUserId = newTickets.tickets_id;
            return true;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return false;
        }
    }

    public bool AuthorizeUser(string userEmail, string userPassword)
    {
        List<User> records = _db.Query<User>("select * from users where usr_login = ? and usr_password = ?", new object[] {userEmail, userPassword});

        if (records.Count == 0) return false;

        currentUserId = records[0].usr_id;
        return true;
    }

    public bool AuthorizeAdmin(string userEmail, string userPassword)
    {
            List<User> records = _db.Query<User>("select * from administrators where adm_login = ? and adm_password = ?", new object[] {userEmail, userPassword});

            if (records.Count == 0) return false;

            currentUserId = records[0].usr_id;
            return true;
    }
    public bool TicketsAll()
    {
            List<Tickets> records = _db.Query<Tickets>("select * from tickets");

            if (records.Count == 0) return false;

            currentUserId = records[0].tickets_id;
            return true;
    }


    public bool DeleteAll()
    {
            List<Tickets> records = _db.Query<Tickets>("DELETE FROM tickets");
            return true;
    }

    public void EditUsers(string userLogin, string userPassword)
    {
        User editedUser = GetUserById(currentUserId);

        editedUser.usr_login = userLogin;
        editedUser.usr_password = userPassword;

        _db.Update(editedUser);
        _db.Commit();
    }

    public List<User> GetLabs()
    {
        List<User> records = _db.Query<User>("select * from users");

        return records;
    }

    public string GetUserlogin()
    {
        List<User> records = _db.Query<User>("select * from users where usr_id = ?", new object[] {currentUserId});

        return records[0].usr_login;
    }
    public string GetUserPassword()
    {
        List<User> records = _db.Query<User>("select * from users where usr_id = ?", new object[] {currentUserId});

        return records[0].usr_password;
    }

    public User GetUserById(int labId)
    {
        List<User> records = _db.Query<User>("select * from users where usr_id = ?", labId);
        return records[0];
    }

    public string GetTicketsName()
    {
            List<Tickets> records = _db.Query<Tickets>("select * from tickets where tickets_id = ?", new object[] { currentTicketId });
            return records[0].tickets_price;    
            
    }
    public string GetTicketsNametwo()
    {
            List<Tickets> records = _db.Query<Tickets>("select * from tickets where tickets_id = ?", new object[] { currentTicketId });

            return records[0].tickets_place;
    }
    public string GetTicketsNamethree()
    {
            List<Tickets> records = _db.Query<Tickets>("select * from tickets where tickets_id = ?", new object[] { currentTicketId });

            return records[0].tickets_data;
    }

    private bool CheckUser()
    {
        return currentUserId >= 0;
    }
}