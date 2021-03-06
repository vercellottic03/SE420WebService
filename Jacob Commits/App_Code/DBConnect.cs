﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBConnect
/// </summary>
public class DBConnect
{
    //database object
    private MySqlConnection connection;
    //server string, will be assigned value of feathersup server
    private string server;
    private string database;
    private string uid;
    private string password;
    public string connectionString;

    //Constructor
    public DBConnect()
    {
        //Creates an instance of the DBConnect object, with variables filled in
        Initialize();
    }

    //Initialize values to use as credentials for database connection
    public void Initialize()
    {
        /*
        To connect to Jon's database uncomment this code. 

        server = "localhost";
        database = "advise";
        uid = "elizabeth";
        password = "^guesswhoSE420$";
        string connectionString;
        connectionString = "SERVER=" + server + ";PORT=306;" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        connection = new MySqlConnection(connectionString);
        */

        server = "localhost";
        database = "advise";
        uid = "root";
        password = "jacob";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        connection = new MySqlConnection(connectionString);
    }

    public MySqlConnection getConn()
    {
        return connection;
    }

    //attempt to open connection to database
    public bool OpenConnection()
    {
        try
        {
            //Attempts to open the database connection
            connection.Open();
            return true;
        }
        //Catch any errors that may occur and repor them
        catch (MySqlException ex)
        {
            //Catches MySqlConnectionFailure
            return false;
        }
    }
    public bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            return false;
        }

    }
}