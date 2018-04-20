using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _1_oop_project_gym
{
    abstract class person
    {

        #region Paramters

        public int Id;
        public string Name;

        #endregion

        #region defult constructor

        public person()
        {
            Id = 0;
            Name = "kk";
        }

        #endregion

        #region constructor by paramters

        public person(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        #endregion

        #region All functions Customers

        public virtual void add() { }
        public virtual void edit() { }
        public virtual void delete() { }
        public abstract DataTable search(string name);
        public abstract DataTable display();
       
       #endregion   

    }

    class Customers : person
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");
        public int cost;
        public DateTime froms;
        public DateTime tos;
        public int kind_of_exer_id;
        public string Acount;
        public string password;
        public int gender_id;

        #endregion

        #region defult constructor

        public Customers()
        {
           // this.Id = id;
            this.Name = "unknow";
            this.cost = 0;
            this.froms = DateTime.Now;
            this.tos = DateTime.Now;
            this.kind_of_exer_id = 1;
            this.Acount = "unknow";
            this.password = "0000";
            this.gender_id = 1;
        }

        #endregion

        #region constructor by paramters

        public Customers(string name, int c ,DateTime f,DateTime t, int kind_id, string acount, string pass, int gender)
        {
           // this.Id = id;
            this.Name = name;
            this.cost = c;
            this.froms = f;
            this.tos = t;
            this.kind_of_exer_id = kind_id;
            this.Acount = acount;
            this.password = pass;
            this.gender_id = gender;
        }

        #endregion

        #region Function add customers

        public virtual void add(Customers c1)
        {
            try
            {
                #region Paramters

                SqlCommand cmd;

                #endregion

                con.Open();
                cmd = new SqlCommand("insert into Customer (Customers_Name,Cost,Froms,Tos,kind_of_exer_id,Acount,Passwords,gender_id) values ('" + c1.Name + "','" + c1.cost + "','" + c1.froms + "', '" + c1.tos + "','" + c1.kind_of_exer_id + "','" + c1.Acount + "','" + c1.password + "','" + c1.gender_id + "') ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Registeration was sucsessful");
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please check Name ");
            }
        }

        #endregion

        #region Function edit customers

        public virtual void edit(Customers c1, string n)
        {
            try
            {

                #region Paramters

                SqlCommand cmd;

                #endregion

                con.Open();

                cmd = new SqlCommand("update Customer set Customers_Name='" + c1.Name + "', Cost='" + c1.cost + "', Froms='" + c1.froms + "', Tos='" + c1.tos + "', kind_of_exer_id='" + c1.kind_of_exer_id + "', Acount='" + c1.Acount + "', Passwords='" + c1.password + "', gender_id='" + c1.gender_id + "' where Customers_Name='" + n + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Update was sucsessful");
                con.Close();
            }
            catch (Exception)
            {                
                MessageBox.Show("Please check Name ");
            }
        }

        #endregion

        #region Function delete customers

        public virtual void delete(string name)
        {

            #region Paramters

            SqlCommand cmd;

            #endregion

            con.Open();
            cmd = new SqlCommand("delete from Customer where Customers_Name='" + name + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your delete was sucsessful");
            con.Close();
        }

        #endregion

        #region Function search one customers to update

        public override DataTable search(string name)
        {

            #region paramter

            DataTable dt_grid_info = new DataTable();
            SqlDataAdapter da_show_info;

            #endregion

            con.Open();
            dt_grid_info.Clear();
            da_show_info = new SqlDataAdapter("select Customer.ID,Customer.Customers_Name,Customer.Cost,Customer.Froms,Customer.Tos,Kind_of_equip_or_exer.kind_Name,Customer.Acount,Customer.Passwords,Gender.Kind from Customer inner join Kind_of_equip_or_exer on Customer.kind_of_exer_id=Kind_of_equip_or_exer.ID inner join Gender on Customer.gender_id=Gender.ID where Customers_Name='" + name + "'", con);
            da_show_info.Fill(dt_grid_info);
            con.Close(); 
            return dt_grid_info;
             
        }

        #endregion

        #region Function display all customers

        public override DataTable display()
        {
            
            #region paramter

            DataTable dt_grid_info = new DataTable();
            SqlDataAdapter da_show_info;

            #endregion

            con.Open();
            dt_grid_info.Clear();
            da_show_info = new SqlDataAdapter("select Customer.ID,Customer.Customers_Name,Customer.Cost,Customer.Froms,Customer.Tos,Kind_of_equip_or_exer.kind_Name,Customer.Acount,Customer.Passwords,Gender.Kind from Customer inner join Kind_of_equip_or_exer on Customer.kind_of_exer_id=Kind_of_equip_or_exer.ID inner join Gender on Customer.gender_id=Gender.ID", con);
            da_show_info.Fill(dt_grid_info);
            con.Close();
            return dt_grid_info;

        }

        #endregion

    }

    class Trainers : person
    {

        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");
        public int Salary;
        public int halls_id;
        public int manager_id;
        public string froms;
        public string tos;

        #endregion

        #region defult constructor

        public Trainers()
        {
            this.Name = "unknow";
            this.Salary = 1200;
            this.halls_id = 1;
            this.manager_id = 1;
            this.froms ="12 pm";
            this.tos = "8 pm";
        }

        #endregion

        #region constructor by paramters

        public Trainers(string name, int s, int ha_id, int man_id, string f, string t)
        {
            this.Name = name;
            this.Salary = s;
            this.halls_id = ha_id;
            this.manager_id = man_id;
            this.froms = f;
            this.tos = t;
        }

        #endregion

        #region Function add Trainers

        public virtual void add(Trainers c1)
        {

            #region Paramters

            SqlCommand cmd;

            #endregion
            try
            {
                con.Open();
                cmd = new SqlCommand("insert into Traineer (Traineer_Name,Sallary,halls_id,manager_id,Froms,Tos) values ('" + c1.Name + "','" + c1.Salary + "','" + c1.halls_id + "', '" + c1.manager_id + "','" + c1.froms + "','" + c1.tos + "') ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Registeration was sucsessful");
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please check Name or Salary");
            }

            
        }

        #endregion

        #region Function edit Trainers

        public virtual void edit(Trainers c1, string n)
        {
            try
            {

                #region Paramters

                SqlCommand cmd;

                #endregion

                con.Open();

                cmd = new SqlCommand("update Traineer set Traineer_Name='" + c1.Name + "', Sallary='" + c1.Salary + "', halls_id='" + c1.halls_id + "', manager_id='" + c1.manager_id + "', Froms='" + c1.froms + "', Tos='" + c1.tos + "' where Traineer_Name='" + n + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Update was sucsessful");
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please check Name or Salary");
            }
        }

        #endregion

        #region Function delete Trainers

        public virtual void delete(string name)
        {

            #region Paramters

            SqlCommand cmd;

            #endregion

            con.Open();
            cmd = new SqlCommand("delete from Traineer where Traineer_Name='" + name + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your delete was sucsessful");
            con.Close();
        }

        #endregion

        #region Function search one Trainers to update

        public override DataTable search(string name)
        {

            #region paramter

            DataTable dt_grid_info = new DataTable();
            SqlDataAdapter da_show_info;

            #endregion

            con.Open();
            dt_grid_info.Clear();
            da_show_info = new SqlDataAdapter("select Traineer.ID,Traineer.Traineer_Name,Traineer.Sallary,Halls.Halls_Name,Manager.manager_Name,Traineer.Froms,Traineer.Tos from Traineer inner join Halls on Traineer.halls_id=Halls.ID inner join Manager on Traineer.manager_id=Manager.ID where Traineer_Name='" + name + "'", con);
            da_show_info.Fill(dt_grid_info);
            con.Close();
            return dt_grid_info;

        }

        #endregion
       
        #region Function display all Trainers

        public override DataTable display()
        {

            #region paramter

            DataTable dt_grid_info = new DataTable();
            SqlDataAdapter da_show_info;

            #endregion

            con.Open();
            dt_grid_info.Clear();
            da_show_info = new SqlDataAdapter("select Traineer.ID,Traineer.Traineer_Name,Traineer.Sallary,Halls.Halls_Name,Manager.manager_Name,Traineer.Froms,Traineer.Tos from Traineer inner join Halls on Traineer.halls_id=Halls.ID inner join Manager on Traineer.manager_id=Manager.ID", con);
            da_show_info.Fill(dt_grid_info);
            con.Close();
            return dt_grid_info;

        }

        #endregion

        public static int operator +(Trainers t1, int x)
        {
            Trainers t2 = new Trainers();
            t2.Salary = t1.Salary + x;
            return t2.Salary;
        }
    }

    class Managers : person
    {

        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");
        public string acount;
        public string pass;
        #endregion

        #region defult constructor

        public Managers()
        {
            this.Name = "unknow";
            this.acount = "unknow";
            this.pass = "0000";
        }

        #endregion

        #region constructor by paramters

        public Managers(string name,string a,string p)
        {
            this.Name = name;
            this.acount = a;
            this.pass = p;
        }

        #endregion

        #region embity Function add and edit and delete Managers

        public virtual void add(Managers c1) { }
        public virtual void edit(Managers c1, string n) { }
        public virtual void delete(string name) { }
         
        #endregion

        #region Function search one Trainers to update

        public override DataTable search(string name)
        {

            #region paramter

            DataTable dt_grid_info = new DataTable();
            SqlDataAdapter da_show_info;

            #endregion

            con.Open();
            dt_grid_info.Clear();
            da_show_info = new SqlDataAdapter("select Traineer.ID,Traineer.Traineer_Name,Traineer.Sallary,Halls.Halls_Name,Manager.manager_Name,Traineer.Froms,Traineer.Tos from Traineer inner join Halls on Traineer.halls_id=Halls.ID inner join Manager on Traineer.manager_id=Manager.ID where Traineer_Name='" + name + "'", con);
            da_show_info.Fill(dt_grid_info);
            con.Close();
            return dt_grid_info;

        }

        #endregion

        #region Function display all Trainers

        public override DataTable display()
        {

            #region paramter

            DataTable dt_grid_info = new DataTable();
            SqlDataAdapter da_show_info;

            #endregion

            con.Open();
            dt_grid_info.Clear();
            da_show_info = new SqlDataAdapter("select Traineer.ID,Traineer.Traineer_Name,Traineer.Sallary,Halls.Halls_Name,Manager.manager_Name,Traineer.Froms,Traineer.Tos from Traineer inner join Halls on Traineer.halls_id=Halls.ID inner join Manager on Traineer.manager_id=Manager.ID", con);
            da_show_info.Fill(dt_grid_info);
            con.Close();
            return dt_grid_info;

        }

        #endregion

    }

    class Equipments
    {
         #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");
        public int Id;
        public string Name; 
        public int count;
        public int hall_id;
        public int kind_of_exer_id;

        #endregion

        #region defult constructor

        public Equipments()
        {
           // this.Id = id;
            this.Name = "unknow";
            this.count = 0;
            this.hall_id = 1;
            this.kind_of_exer_id = 1;
        }

        #endregion

        #region constructor by paramters

        public Equipments(string name, int c, int ha_id, int kind_id)
        {
            this.Name = name;
            this.count = c;
            this.hall_id = ha_id;
            this.kind_of_exer_id = kind_id;
        }

        #endregion

        #region Function add Equipments

        public void add1(Equipments c2)
        {
            try
            {
                #region Paramters

                SqlCommand cmd;
                SqlDataReader reader;

                #endregion

                con.Open();
                cmd = new SqlCommand("insert into Equipments (equip_Name,Counts,halls_id,[Kind of equip_exer_id]) values ('" + c2.Name + "','" + c2.count + "','" + c2.hall_id + "', '" + c2.kind_of_exer_id + "') ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Registeration was sucsessful");
                con.Close();
            }
            catch (Exception)
            {                
                MessageBox.Show("Please check Name ");
            }
            
        }

        #endregion

        #region Function edit Equipments

        public void edit1(Equipments c1, string n)
        {
            try
            {
                #region Paramters

                SqlCommand cmd;

                #endregion

                con.Open();

                cmd = new SqlCommand("update Equipments set equip_Name='" + c1.Name + "', Counts='" + c1.count + "', halls_id='" + c1.hall_id + "', [Kind of equip_exer_id]='" + c1.kind_of_exer_id + "'where equip_Name='" + n + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Update was sucsessful");
                con.Close();
            }
            catch (Exception)
            {                
                MessageBox.Show("Please check Name ");
            }
        }

        #endregion

        #region Function delete Equipments

        public void delete1(string name)
        {

            #region Paramters

            SqlCommand cmd;

            #endregion

            con.Open();
            cmd = new SqlCommand("delete from Equipments where equip_Name='" + name + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your delete was sucsessful");
            con.Close();

        }

        #endregion

        #region Function search one Equipments to update

        public DataTable search1(string name)
        {

            #region paramter

            DataTable dt_grid_info = new DataTable();
            SqlDataAdapter da_show_info;

            #endregion

            con.Open();
            dt_grid_info.Clear();
            da_show_info = new SqlDataAdapter("select Equipments.ID,Equipments.equip_Name,Equipments.Counts,Halls.Halls_Name,Kind_of_equip_or_exer.kind_Name from Equipments inner join Halls on Equipments.halls_id=Halls.ID inner join Kind_of_equip_or_exer on Equipments.[Kind of equip_exer_id]=Kind_of_equip_or_exer.ID where Equipments.equip_Name='" + name + "'", con);
            da_show_info.Fill(dt_grid_info);
            con.Close();
            return dt_grid_info;

        }

        #endregion   

        #region Function display all Equipments

        public DataTable display1()
        {

            #region paramter

            DataTable dt_grid_info = new DataTable();
            SqlDataAdapter da_show_info;

            #endregion

            con.Open();
            dt_grid_info.Clear();
            da_show_info = new SqlDataAdapter("select Equipments.equip_Name,Equipments.Counts,Halls.Halls_Name,Kind_of_equip_or_exer.kind_Name from Equipments inner join Halls on Equipments.halls_id=Halls.ID inner join Kind_of_equip_or_exer on Equipments.[Kind of equip_exer_id]=Kind_of_equip_or_exer.ID ", con);
            da_show_info.Fill(dt_grid_info);
            con.Close();
            return dt_grid_info;

        }

        #endregion
       
    }

    class Exercise_Plane
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");
        public int Id;
        public int halls_id;
        public int equip_id;
        public int month_id;

        #endregion

        #region defult constructor

        public Exercise_Plane()
        {
            this.halls_id = 1;
            this.equip_id = 1;
            this.month_id = 1;
        }

        #endregion

        #region constructor by paramters

        public Exercise_Plane(string name, int ha_id, int eq_id, int mo_id)
        {
            this.halls_id = ha_id;
            this.equip_id = eq_id;
            this.month_id = mo_id;
        }

        #endregion

        #region Function add Exercise_Plane

        public void add1(Exercise_Plane c2)
        {

            #region Paramters

            SqlCommand cmd;

            #endregion

            con.Open();
            cmd = new SqlCommand("insert into [Exercise Plane] (halls_id,equip_id,month_id) values ('" + c2.halls_id + "','" + c2.equip_id + "', '" + c2.month_id + "') ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your Registeration was sucsessful");
            con.Close();
        }

        #endregion

        #region Function edit Exercise_Plane

        public void edit1(Exercise_Plane c1, int n)
        {
           
            #region Paramters

            SqlCommand cmd;

            #endregion

            con.Open();

            cmd = new SqlCommand("update [Exercise Plane] set halls_id='" + c1.halls_id + "', equip_id='" + c1.equip_id + "', month_id='" + c1.month_id + "'where ID='" + n + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your Update was sucsessful");
            con.Close();
        }

        #endregion

        #region Function delete Exercise_Plane

        public void delete1(int n)
        {

            #region Paramters

            SqlCommand cmd;

            #endregion

            con.Open();
            cmd = new SqlCommand("delete from [Exercise Plane] where ID='" + n + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your delete was sucsessful");
            con.Close();

        }

        #endregion

        #region Function search one Exercise_Plane to update

        public DataTable search1(int n)
        {

            #region paramter

            DataTable dt_grid_info = new DataTable();
            SqlDataAdapter da_show_info;

            #endregion

            con.Open();
            dt_grid_info.Clear();
            da_show_info = new SqlDataAdapter("select [Exercise Plane].ID,Halls.Halls_Name,Equipments.equip_Name,Months.month_number from [Exercise Plane] inner join Halls on [Exercise Plane].halls_id=Halls.ID inner join Equipments on [Exercise Plane].equip_id=Equipments.ID inner join Months on [Exercise Plane].month_id=Months.ID where [Exercise Plane].ID='" + n + "'", con);
            da_show_info.Fill(dt_grid_info);
            con.Close();
            return dt_grid_info;

        }

        #endregion  

        #region Function display all Exercise_Plane

        public DataTable display1()
        {

            #region paramter

            DataTable dt_grid_info = new DataTable();
            SqlDataAdapter da_show_info;

            #endregion

            con.Open();
            dt_grid_info.Clear();
            da_show_info = new SqlDataAdapter("select [Exercise Plane].ID,Halls.Halls_Name,Equipments.equip_Name,Months.month_number from [Exercise Plane] inner join Halls on [Exercise Plane].halls_id=Halls.ID inner join Equipments on [Exercise Plane].equip_id=Equipments.ID inner join Months on [Exercise Plane].month_id=Months.ID ", con);
            da_show_info.Fill(dt_grid_info);
            con.Close();
            return dt_grid_info;

        }

        #endregion

    }

    class Halls
    {

        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");
        public int Id;
        public string Name;
        #endregion

        #region defult constructor

        public Halls()
        {
            this.Name = "unknow";
        }

        #endregion

        #region constructor by paramters

        public Halls(string name)
        {
            this.Name = name;
        }

        #endregion

        #region Function add Halls

        public void add1(Halls c2)
        {
            try
            {
                #region Paramters

                SqlCommand cmd;

                #endregion

                con.Open();
                cmd = new SqlCommand("insert into Halls (Halls_Name) values ('" + c2.Name + "') ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Registeration was sucsessful");
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please check Name ");
            }
        }

        #endregion

        #region Function edit Halls

        public void edit1(Halls c1, string n)
        {
            try
            {
                #region Paramters

                SqlCommand cmd;

                #endregion

                con.Open();
                cmd = new SqlCommand("update Halls set Halls_Name='" + c1.Name + "'where Halls_Name='" + n + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Update was sucsessful");
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please check Name ");
            }
        }

        #endregion

        #region Function delete Halls

        public void delete1(string name)
        {
            try
            {
                #region Paramters

                SqlCommand cmd;

                #endregion

                con.Open();
                cmd = new SqlCommand("delete from Halls where Halls_Name='" + name + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your delete was sucsessful");
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please check Your Date in SQL ");
            }
        }

        #endregion

        #region Function search one Halls to update

        public DataTable search1(string name)
        {

            #region paramter

            DataTable dt_grid_info = new DataTable();
            SqlDataAdapter da_show_info;

            #endregion

            con.Open();
            dt_grid_info.Clear();
            da_show_info = new SqlDataAdapter("select Equipments.equip_Name from Equipments inner join Halls on Equipments.halls_id=Halls.ID where Halls.Halls_Name='" + name + "'", con);
            da_show_info.Fill(dt_grid_info);
            con.Close();
            return dt_grid_info;

        }

        #endregion

        #region Function display all Halls

        public DataTable display1()
        {

            #region paramter

            DataTable dt_grid_info = new DataTable();
            SqlDataAdapter da_show_info;

            #endregion

            con.Open();
            dt_grid_info.Clear();
            da_show_info = new SqlDataAdapter(" select Halls_Name from Halls ", con);
            da_show_info.Fill(dt_grid_info);
            con.Close();
            return dt_grid_info;

        }

        #endregion
    }

}