/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 11/8/7016
 * Time: 11:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace reader
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		static string temp_tabel,kbaza,MyStringCon,idRegistru,analiza,valoare,limite;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			init();
			DropTable();
			CreateTable();
			readText("random path to text");
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public static void init()
		{
			string[] text = System.IO.File.ReadAllLines(@"path-to-config");
            int poz = text[0].IndexOf(" ");
            string baza = text[0].Substring(0, poz);
            string text1 = text[0].Substring(poz + 1, text[0].Length - poz - 1);
            poz = text1.IndexOf(" ");
            string host = text1.Substring(0, poz);
            kbaza=baza;
            temp_tabel=kbaza+".temp_"+Environment.MachineName+"H";
            temp_tabel=temp_tabel.Replace("-","");


            MyStringCon = "SERVER=" + host + ";" +
                 "DATABASE=" + baza + ";" +
                 "UID=user_cass; PASSWORD=" + "password_cass" + ";pooling=true;Allow Zero Datetime=True;Min Pool Size=1; Max Pool Size=100; ";
		}
		public static void DropTable()
		{
			
			using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     						
     						cmdP.CommandText = "DROP TABLE IF EXISTS "+temp_tabel;
          						cmdP.ExecuteNonQuery();
     					}
			}
			
		}
		public void readText(string fileName){
			int a=7;
	var lines = File.ReadLines(fileName);
foreach (var line in lines)	{
		if(a==7){
		
		//read id reg
		if (line.StartsWith("<p><n>SEQ</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	idRegistru=wordsnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "INSERT INTO " + temp_tabel + " (id) VALUES (@id);";
     							cmdP.Parameters.AddWithValue("@id",idRegistru);
     							cmdP.ExecuteNonQuery();
     					}
			}
	a=3;
	}
		}
		//read datas
		if(a==3){
			if (line.StartsWith("<p><n>RBC</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set analiza='"+analiza+"',val_analiza='"+valoare+"',limita='"+limite+"' WHERE id ="+idRegistru+";";
     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>MCV</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set MCVanaliza='"+analiza+"',MCVval_analiza='"+valoare+"',MCVlimita='"+limite+"' WHERE id = "+idRegistru+";";
     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>HCT</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set HCTanaliza='"+analiza+"',HCTval_analiza='"+valoare+"',HCTlimita='"+limite+"' WHERE id =  "+idRegistru+";";
 
     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>MCH</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set MCHanaliza='"+analiza+"',MCHval_analiza='"+valoare+"',MCHlimita='"+limite+"' WHERE id =  "+idRegistru+";";
     			
     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>MCHC</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set MCHCanaliza='"+analiza+"',MCHCval_analiza='"+valoare+"',MCHClimita='"+limite+"' WHERE id =  "+idRegistru+";";
     				
     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>RDWR</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set RDWRanaliza='"+analiza+"',RDWRval_analiza='"+valoare+"',RDWRlimita='"+limite+"' WHERE id =  "+idRegistru+";";

     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>RDWA</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set RDWAanaliza='"+analiza+"',RDWAval_analiza='"+valoare+"',RDWAlimita='"+limite+"' WHERE id =  "+idRegistru+";";

     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>PLT</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set PLTanaliza='"+analiza+"',PLTval_analiza='"+valoare+"',PLTlimita='"+limite+"' WHERE id = "+idRegistru+";";

     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>MPV</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set MPVanaliza='"+analiza+"',MPVval_analiza='"+valoare+"',MPVlimita='"+limite+"' WHERE id =  "+idRegistru+";";

     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>PCT</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set PCTanaliza='"+analiza+"',PCTval_analiza='"+valoare+"',PCTlimita='"+limite+"' WHERE id =  "+idRegistru+";";
     		
     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>PDW</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set PDWanaliza='"+analiza+"',PDWval_analiza='"+valoare+"',PDWlimita='"+limite+"' WHERE id =  "+idRegistru+";";

     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>LPCR</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set LPCRanaliza='"+analiza+"',LPCRval_analiza='"+valoare+"',LPCRlimita='"+limite+"' WHERE id =  "+idRegistru+";";
     				
     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>HGB</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set HGBanaliza='"+analiza+"',HGBval_analiza='"+valoare+"',HGBlimita='"+limite+"' WHERE id =  "+idRegistru+";";
     				
     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>WBC</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set WBCanaliza='"+analiza+"',WBCval_analiza='"+valoare+"',WBClimita='"+limite+"' WHERE id = "+idRegistru+";";
     	
     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>LA</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set LAanaliza='"+analiza+"',LAval_analiza='"+valoare+"',LAlimita='"+limite+"' WHERE id = "+idRegistru+";";
     			
     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>MA</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set MAanaliza='"+analiza+"',MAval_analiza='"+valoare+"',MAlimita='"+limite+"' WHERE id =  "+idRegistru+";";
     					
     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>GA</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set GAanaliza='"+analiza+"',GAval_analiza='"+valoare+"',GAlimita='"+limite+"' WHERE id =  "+idRegistru+";";
     							
     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>LR</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set LRanaliza='"+analiza+"',LRval_analiza='"+valoare+"',LRlimita='"+limite+"' WHERE id =  "+idRegistru+";";
     							
     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>MR</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set MRanaliza='"+analiza+"',MRval_analiza='"+valoare+"',MRlimita='"+limite+"' WHERE id =  "+idRegistru+";";
     							
     							cmdP.ExecuteNonQuery();
     					}
			}
	}
			if (line.StartsWith("<p><n>GR</n><v>"))
	{
	string[] words = line.Split('>');
	String splitAgain=words[4];
	string[] wordsnew = splitAgain.Split('<');
	if(wordsnew.Length==0){}else
	analiza=wordsnew[0];
	string[] wordsval = splitAgain.Split('>');
	String splitval="";
	if(wordsval.Length==0){}else
	splitval=words[7];
	string[] wordsvalnew = splitval.Split('<');
	if(wordsvalnew.Length==0){}else
	valoare=wordsvalnew[0];
	string[] wordslimite = splitval.Split('>');
	String splitlimite="";
	if(wordslimite.Length==0){}else
	splitlimite=words[9];
	string[] wordslimtnew = splitlimite.Split('<');
	if(wordslimtnew.Length==0){}else
	limite=wordslimtnew[0];
	using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "update " + temp_tabel + " set GRanaliza='"+analiza+"',GRval_analiza='"+valoare+"',GRlimita='"+limite+"' WHERE id =  "+idRegistru+";";
     							
     							cmdP.ExecuteNonQuery();
     					}
			}
	a=5;
	}
			
		}
		
	
	
	
	}
	MessageBox.Show("Dot Net Perls is awesome.",
    "Important Message");
		}
		
		public static void CreateTable()
		{
			
			using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
          						cmdP.CommandText = "CREATE TABLE "+temp_tabel+" ("+
"`nr_crt`  int(3) NOT NULL AUTO_INCREMENT PRIMARY KEy,"+
"`id`  varchar(30) NULL DEFAULT NULL ,"+
"`analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`val_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`limita`  varchar(50) NULL DEFAULT NULL ,"+
"`MCVanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`MCVval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`MCVlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`HCTanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`HCTval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`HCTlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`HTCanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`HTCval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`HTClimita`  varchar(50) NULL DEFAULT NULL ,"+
"`MCHanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`MCHval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`MCHlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`MCHCanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`MCHCval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`MCHClimita`  varchar(50) NULL DEFAULT NULL ,"+
"`RDWRanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`RDWRval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`RDWRlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`RDWAanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`RDWAval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`RDWAlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`PLTanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`PLTval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`PLTlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`MPVanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`MPVval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`MPVlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`PCTanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`PCTval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`PCTlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`PDWanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`PDWval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`PDWlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`LPCRanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`LPCRval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`LPCRlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`HGBanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`HGBval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`HGBlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`WBCanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`WBCval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`WBClimita`  varchar(50) NULL DEFAULT NULL ,"+
"`LAanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`LAval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`LAlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`MAanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`MAval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`MAlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`GAanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`GAval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`GAlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`LRanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`LRval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`LRlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`MRanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`MRval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`MRlimita`  varchar(50) NULL DEFAULT NULL ,"+
"`GRanaliza`  varchar(50) NULL DEFAULT NULL ,"+
"`GRval_analiza`  varchar(50) NULL DEFAULT NULL ,"+
"`GRlimita`  varchar(50) NULL DEFAULT NULL)"
          							;
          						cmdP.ExecuteNonQuery();
     					}
			}
		}
		public static void insertTable(string id,string analiza,string val_analiza,string limita)
		{
			using (var connP = new MySqlConnection(MyStringCon))
						{
     					connP.Open();
     					using (MySqlCommand cmdP = connP.CreateCommand())
     						{
     							cmdP.CommandText = "INSERT INTO " + temp_tabel + " (id,analiza,val_analiza,limita) VALUES (@id,@analiza,@val_analiza,@um);";
     							cmdP.Parameters.AddWithValue("@analiza",analiza);
     							cmdP.Parameters.AddWithValue("@val_analiza",val_analiza);
     							cmdP.Parameters.AddWithValue("@um",limita);
     							cmdP.Parameters.AddWithValue("@id",id);
     							cmdP.ExecuteNonQuery();
     					}
			}
		}
		
	}
}
