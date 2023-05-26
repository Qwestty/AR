using SQLite4Unity3d;
using UnityEngine;
using nsDB;
using System;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService
{
    private SQLiteConnection _connection;

    static Type[] tables =
    {
        typeof(Administrators),
        typeof(Attraction),
        typeof(Budget),
        typeof(Cities),
        typeof(FeaturedTickets),
        typeof(Hotels),
        typeof(User),
        typeof(Reviews),
        typeof(Country),
        typeof(PurchasedTickets),
        typeof(Tickets),
    };

    static string[] tablenames =
    {
        "administrators",
        "attraction",
        "Budget",
        "cities",
        "featuredTickets",
        "hotels",
        "users",
        "reviews",
        "country",
        "purchasedTickets",
        "tickets",
    };


    public DataService(string DatabaseName)
    {
#if UNITY_EDITOR
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
            var loadDb =
 new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb =
 Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb =
 Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb =
 Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);

#elif UNITY_STANDALONE_OSX
		var loadDb =
 Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb =
 Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);
    }

    public void CreateDB()
    {
        createtables();
    }

    public void droptables()
    {
        _connection.DropTable<Administrators>();
        _connection.DropTable<Attraction>();
        _connection.DropTable<Budget>();
        _connection.DropTable<Cities>();
        _connection.DropTable<FeaturedTickets>();
        _connection.DropTable<Hotels>();
        _connection.DropTable<User>();
        _connection.DropTable<Reviews>();
        _connection.DropTable<Country>();
        _connection.DropTable<PurchasedTickets>();
        _connection.DropTable<Tickets>();
    }

    public void createtables()
    {
        _connection.CreateTable<Administrators>();
        _connection.CreateTable<Attraction>();
        _connection.CreateTable<Budget>();
        _connection.CreateTable<Cities>();
        _connection.CreateTable<FeaturedTickets>();
        _connection.CreateTable<Hotels>();
        _connection.CreateTable<User>();
        _connection.CreateTable<Reviews>();
        _connection.CreateTable<Country>();
        _connection.CreateTable<PurchasedTickets>();
        _connection.CreateTable<Tickets>();

        _connection.CreateIndex("i_user_1", "users", new string[] { "usr_name" }, true);
    }

    public SQLiteConnection getConn()
    {
        return (_connection);
    }

    public void clearDB()
    {
        for (int i = 0; i < tables.Length; i++)
        {
            _connection.Execute("delete from " + tablenames[i]);
        }

        _connection.Execute("vacuum;");
    }

    public int selectCount(string query)
    {
        int qq = _connection.ExecuteScalar<int>(query);
        return qq;
    }

    public int selectCount(string query, System.Object[] o)
    {
        int qq = _connection.ExecuteScalar<int>(query, o);
        return qq;
    }

    public string selectString(string query)
    {
        string qq = _connection.ExecuteScalar<string>(query);
        return qq;
    }
}