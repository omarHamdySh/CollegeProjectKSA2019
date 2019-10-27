using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;
using System.Net.Sockets;


#region Tabels Columns Names and Data Types
/**
 * tabel name= assemblytest         [int UserId,int MinutesSpent,int SecondsSpent]
 * 
 * tabel name= assemblytraining     [int UserId,string GPA,int Result]
 * 
 * tabel name= shootingtest         [int UserId,int TargetsMiss,int TargetsHits,float Accuracy,int ShootingRange,int minutesSpent,int SecondsSpent]
 * 
 * tabel name= shootingtraining     [int UserId,string WeaponName,int BulletsNumber,string GPA,int ShootingRange,float Accuracy]
 * 
 * tabel name= userdata                 [int ID,string UserName,string Password,bool FirstTime]
 * 
 */
#endregion


public class DbManager : MonoBehaviour
{


    private static DbManager _Instance;                               //reference for this script to access it from another place to manage/control his variables and function

    public static DbManager Instance
    {
        get { return _Instance; }

    }

    private void Awake()
    {
        /** Order of methods calling is critical**/
        if (_Instance == null)
        {
            _Instance = this;
        }
    }
  

    //Initialize All Database Main Variables 
    public string dbDataSource = "127.0.0.1";
    public string dbName = "collageksadb";
    //i creates a user have all privilages
    public string dbUserName = "bright";
    public string dbPassword = "bright123";
    public UInt16 dbPort = 3306;
    MySqlConnection dbConnection;
    //Test Parm
    public InputField RegInputUserName;
    public InputField RegInputPassword;
    public InputField SignInputUserName;
    public InputField SignInputPassword;
    public InputField ServerIpAdrees;
    public Text deviceIp;
    public Text ErrorDialougText;
    //end Test
    private void Start()
    {
        deviceIp.text ="device IP "+ GetLocalIPAddress();
    }
    public static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception("No network adapters with an IPv4 address in the system!");
    }
    public bool CheckRegistrationInputValidation()
    {
        if (string.IsNullOrEmpty(RegInputPassword.text) || RegInputPassword.text == "" || RegInputPassword.text == " ")
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "You Did not enter a password";
            return false;
        }
        else if (string.IsNullOrEmpty(RegInputUserName.text) || RegInputUserName.text == "" || RegInputUserName.text == " ")
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "You Did not enter a user name";
            return false;
        }
        Init();
        int y = GetIdByUserNameAndPassword(RegInputUserName.text, RegInputPassword.text);
        if (y == -1)
        {
            CloseDataBaseConnection();
            return false;
        }
        return true; 
    }
    public bool CheckSigningInInputValidation()
    {
        if (string.IsNullOrEmpty(SignInputPassword.text) || SignInputPassword.text == "" || SignInputPassword.text == " ")
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "You Did not enter a password";
            return false;
        }
        else if (string.IsNullOrEmpty(SignInputUserName.text) || SignInputUserName.text == "" || SignInputUserName.text == " ")
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "You Did not enter a user name";
            return false;
        }
        return true;
    }
    public bool CheckServergInInputValidation()
    {
        if (string.IsNullOrEmpty(ServerIpAdrees.text) || ServerIpAdrees.text == "" || ServerIpAdrees.text == " ")
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "Enter a valid ip adress ";
            return false;
        }
   
        return true;
    }
    //Initialize the Database Connection 2
    //open connection 
    public void Init()
    {
        MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder();
        connString.Server = dbDataSource;
        connString.UserID = dbUserName;
        connString.Password = dbPassword;
        connString.Port = dbPort;
        connString.Database = dbName;
        connString.CharacterSet = "utf8";
        dbConnection = new MySqlConnection(connString.ToString());
        try
        {
            dbConnection.Open();
            ErrorDialougText.color = Color.green;
            ErrorDialougText.text = "Successuful Initialization ";

        } catch (Exception e)
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = e.Message;
        }
    }
   //close connection 
    public void CloseDataBaseConnection()
    {
        try
        {
            dbConnection.Close();

        }
        catch (Exception e)
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = e.Message;
        }
    }
    public void RegisternewUser()
    {
        string playerName = RegInputUserName.text.ToLower();
        string playerPassword = RegInputPassword.text.ToLower();
            Init();
            RegisterNewUser(playerName, playerPassword);
        
    }
    public void SignIn()
    {
        string playerName = SignInputUserName.text.ToLower();
        string playerPassword = SignInputPassword.text.ToLower();
        Init();
        if ( SigningIn(playerName, playerPassword))
        {
            ErrorDialougText.color = Color.green;
            ErrorDialougText.text = "Log in Successfull";
            //PlayerBinaryData.Instance.userName = playerName;
            //PlayerBinaryData.Instance.password = playerPassword;
            CloseDataBaseConnection();
            SceneManager.LoadScene("UIScene");
        }
        else
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "Wrong User Name OR Password !! try Again";
        }
    }

    #region Register And Sigin Method
    public void RegisterNewUser(string usernName, string Password)
    {
        try
        {
            MySqlCommand comm = dbConnection.CreateCommand();
            comm.CommandText = "INSERT INTO userdata(UserName,Password,FirstTime) Values(@username,@password,@firsttime)";
            comm.Parameters.AddWithValue("@username", usernName);
            comm.Parameters.AddWithValue("@password", Password);
            comm.Parameters.AddWithValue("@firsttime", 1);
            comm.ExecuteNonQuery();
            ErrorDialougText.color = Color.green;
            ErrorDialougText.text = "New User Added Successully";
        } catch (Exception e)
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "This User Name Is Used Try Another One";

        }
    }
    public bool SigningIn(string userName, string password)
    {
        try
        {
            string query = "SELECT UserName, Password from userdata WHERE UserName='" + userName + "' AND Password = '" + password + "'";
            MySqlCommand comm = new MySqlCommand(query, dbConnection);
            comm.CommandTimeout = 60;
            MySqlDataReader rdr;
            rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Close();
                return true;
            }

        }
        catch (Exception e)
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = e.Message;
        }
        return false;
    }
    public int GetIdByUserNameAndPassword(string username,string pass)
    {
        int temp=-1;
        try
        {
            string query = "SELECT ID from userdata WHERE UserName='" + username + "' AND Password = '" + pass + "'";
            MySqlCommand comm = new MySqlCommand(query, dbConnection);
            comm.CommandTimeout = 60;
            MySqlDataReader rdr;
            rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                temp = rdr.GetInt32(0); ;
            }
            rdr.Close();

        }
        catch (Exception e)
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = e.Message;
        }
        return temp;
    }
    #endregion

    #region Assembly Methods Adding To db
    public void AddNewAssemblyTestDataRecord(int userId, AssembleTestData assemblyTest)
    {
        try
        {
            MySqlCommand comm = dbConnection.CreateCommand();
            comm.CommandText = "INSERT INTO assemblytest(UserId,MinutesSpent,SecondsSpent) Values(@id,@min,@hour)";
            comm.Parameters.AddWithValue("@id", userId);
            comm.Parameters.AddWithValue("@min", assemblyTest.minutes);
            comm.Parameters.AddWithValue("@hour", assemblyTest.seconds);
            comm.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "there is no user with this Id to add record to it ";

        }

    }
    public void AddNewAssemblyTrainingDataRecord(int userId, AssembleTrainingData assemblyTraining)
    {
        try
        {
            MySqlCommand comm = dbConnection.CreateCommand();
            comm.CommandText = "INSERT INTO assemblytraining(UserId,GPA,Result) Values(@id,@gpa,@res)";
            comm.Parameters.AddWithValue("@id", userId);
            comm.Parameters.AddWithValue("@gpa", assemblyTraining.GPA);
            comm.Parameters.AddWithValue("@res", assemblyTraining.result);
            comm.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "there is no user with this Id to add record to it ";

        }

    }
    #endregion

    #region Shooting Methods Adding to db
    public void AddNewShootingTestDataRecord(int userId,ShootingTestData shootingTest)
    {
        try
        {
            MySqlCommand comm = dbConnection.CreateCommand();
            comm.CommandText = "INSERT INTO shootingtest(UserId,TargetsMiss,TargetsHits,Accuracy,ShootingRange,MinutesSpent,SecondsSpent) " +
                               "Values(@id,@miss,@hit,@acc,@rang,@min,@sec)";
            comm.Parameters.AddWithValue("@id", userId);
            comm.Parameters.AddWithValue("@miss", shootingTest.targetMiss);
            comm.Parameters.AddWithValue("@hit",  shootingTest.targetHit);
            comm.Parameters.AddWithValue("@acc",  shootingTest.accuracy);
            comm.Parameters.AddWithValue("@rang", shootingTest.shootingRange);
            comm.Parameters.AddWithValue("@min",  shootingTest.minutesSpent);
            comm.Parameters.AddWithValue("@sec",  shootingTest.secondsSpent);
            comm.ExecuteNonQuery();
            Debug.Log("New Test Shooting Record Added Successully");
        }
        catch (Exception e)
        {
            Debug.Log("Error While adding Test Shooting Record ");
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "there is no user with this Id to add record to it ";

        }

    }
    public void AddNewShootingTrainingDataRecord(int userId,ShootingTrainingData shootingTraining)
    {
        try
        {
            MySqlCommand comm = dbConnection.CreateCommand();
            comm.CommandText = "INSERT INTO shootingtraining(UserId,WeaponName,BulletsNumber,GPA,ShootingRange,Accuracy) " +
                               "Values(@id,@weap,@bull,@gpa,@rang,@acc)";
            comm.Parameters.AddWithValue("@id", userId);
            comm.Parameters.AddWithValue("@weap", shootingTraining.weaponName);
            comm.Parameters.AddWithValue("@bull", shootingTraining.bulletNumbers);
            comm.Parameters.AddWithValue("@gpa", shootingTraining.shootingAccuracyGPA);
            comm.Parameters.AddWithValue("@rang", shootingTraining.shootingRange);
            comm.Parameters.AddWithValue("@acc", shootingTraining.accuracy);
            comm.ExecuteNonQuery();
            Debug.Log("New Training Shooting Record Added Successully");
        }
        catch (Exception e)
        {
            Debug.Log("Error While adding Training Shooting Record "+e.Message);
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "there is no user with this Id to add record to it ";

        }

    }
    #endregion

    #region Get Shoooting Data by User ID
    public  List<ShootingTestData> GetShootingTestRecords(int id)
    {
        List<ShootingTestData> sh = new List<ShootingTestData>();
        try
        {
            string str = "SELECT * FROM `shootingtest` WHERE UserId=" + id;
            MySqlCommand comm = new MySqlCommand(str, dbConnection);
            comm.CommandTimeout = 30;
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
             sh.Add(new ShootingTestData(reader.GetInt32(1), reader.GetInt32(2), reader.GetFloat(3), reader.GetString(7), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6)));
            }
            reader.Close();
        }
        catch (Exception e)
        {
            Debug.LogError("Error While get Test Shooting Record ");
            Debug.LogError(e.ToString());
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "there is no user with this Id to add record to it ";
        }
        return sh;
    }
    public List<ShootingTrainingData> GetShootingTrainingRecord(int id)
    {
        List<ShootingTrainingData> trainignList = new List<ShootingTrainingData>();
        try
        {
            string str = "SELECT * FROM `shootingtraining` WHERE UserId=" + id;
            MySqlCommand comm = new MySqlCommand(str, dbConnection);
            comm.CommandTimeout = 30;
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                trainignList.Add(new ShootingTrainingData(reader.GetInt32(4), reader.GetInt32(2), reader.GetFloat(5), reader.GetString(3),20));
            }
            reader.Close();
        }
        catch (Exception e)
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "there is no user with this Id to add record to it ";
        }
        return trainignList;
    }


    #endregion


    #region Get Assembly Data By User ID

    public List<AssembleTestData> GetAssemblyTestRecord(int id)
    {
        List < AssembleTestData> sh = new List<AssembleTestData>();
        try
        {
            string str = "SELECT * FROM `assemblytest` WHERE UserId=" + id;
            MySqlCommand comm = new MySqlCommand(str, dbConnection);
            comm.CommandTimeout = 30;
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                sh.Add(new AssembleTestData(reader.GetInt32(2), reader.GetInt32(1)));

            }
            reader.Close();
        }
        catch (Exception e)
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "there is no user with this Id to add record to it ";
        }
        return sh;
    }
    public List<AssembleTrainingData> GetAssemblyTrainingRecord(int id)
    {
        List<AssembleTrainingData> sh = new List<AssembleTrainingData>();
        try
        {
            string str = "SELECT * FROM `assemblytraining` WHERE UserId=" + id;
            MySqlCommand comm = new MySqlCommand(str, dbConnection);
            comm.CommandTimeout = 30;
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                sh.Add(new AssembleTrainingData(reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(2), reader.GetString(1)));
            }
            reader.Close();
        }
        catch (Exception e)
        {
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "there is no user with this Id to add record to it ";
        }
        return sh;
    }
    #endregion

    public void GetUserData(int id)
    {
        try
        {
          
            string str = "SELECT * FROM `userdata` WHERE ID="+id;
            MySqlCommand comm = new MySqlCommand(str, dbConnection);
            comm.CommandTimeout = 30;
            MySqlDataReader reader = comm.ExecuteReader();
           while (reader.Read())
            {
                Debug.Log(reader["ID"]);
                Debug.Log(reader["UserName"]);
                Debug.Log(reader["Password"]);
            }
            reader.Close();
          
        }
        catch (Exception e)
        {
            Debug.LogError("Error While Get User  Record ");
            Debug.LogError(e.ToString());
            ErrorDialougText.color = Color.red;
            ErrorDialougText.text = "there is no user with this Id to add record to it ";
        }
    }
 
}