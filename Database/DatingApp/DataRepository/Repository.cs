﻿using System;
using DatingApp.Model;
using Npgsql;
using NpgsqlTypes;

namespace DatingApp.DataRepository
{
    public class Repository : BaseRepository
    {
        //Get a list of students
        public List<Profile> GetProfiles()
        {
            //creating empty list to fill it from database
            var profiles = new List<Profile>();

            //create a new connection for database
            var dbConn = new NpgsqlConnection(ConnectionString);

            //creating an SQL command
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = "select * from student";

            //call the base method to get data
            var data = GetData(dbConn, cmd);

            if (data != null)
            {
                while (data.Read()) //every time loop runs it reads next like from fetched rows
                {
                    Profile s = new Profile(Convert.ToInt32(data["id"]))
                    {
                        FName = data["firstname"].ToString(),
                        LName = data["lastname"].ToString(),
                        StudyProgramID = (int)data["studyprogramid"],
                        DOB = Convert.ToDateTime(data["dob"]),
                        Email = data["email"].ToString(),
                        Phone = data["phone"].ToString()
                    };

                    students.Add(s);

                }

                return students;
            }

            return null;
        }

        //Get a single student using Id
        public Profile GetProfileById(int id)
        {
            //creating empty list to fill it from database
            var profile = new List<Profile>();

            //create a new connection for database
            var dbConn = new NpgsqlConnection(ConnectionString);

            //creating an SQL command
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = $"select * from student where id = {id}";

            //call the base method to get data
            var data = GetData(dbConn, cmd);

            if (data != null)
            {
                if (data.Read()) //if there is any data for given id
                {
                    Profile s = new Profile(Convert.ToInt32(data["id"]))
                    {
                        FirstName = data["firstname"].ToString(),
                        LastName = data["lastname"].ToString(),
                        StudyProgramID = (int)data["studyprogramid"],
                        DOB = Convert.ToDateTime(data["dob"]),
                        Email = data["email"].ToString(),
                        Phone = data["phone"].ToString()
                    };

                    return s;

                }

                return null;
            }

            return null;
        }

        //add a new student
        public bool InsertProfile(Profile s)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"
insert into student
(firstname,lastname, studyprogramid, dob, email, phone)
values
(@firstname,@lastname, @studyprogramid, @dob, @email, @phone)
";

            //adding parameters in a better way
            cmd.Parameters.AddWithValue("@firstname", NpgsqlDbType.Text, s.FirstName);
            cmd.Parameters.AddWithValue("@lastname", NpgsqlDbType.Text, s.LastName);
            cmd.Parameters.AddWithValue("@studyprogramid", NpgsqlDbType.Integer, s.StudyProgramID);
            cmd.Parameters.AddWithValue("@dob", NpgsqlDbType.Date, s.DOB);
            cmd.Parameters.AddWithValue("@email", NpgsqlDbType.Text, s.Email);
            cmd.Parameters.AddWithValue("@phone", NpgsqlDbType.Text, s.Phone);

            //will return true if all goes well
            bool result = InsertData(dbConn, cmd);

            return result;
        }

        public bool UpdateStudent(Profile s)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"
update profile set
    firstname=@firstname,
    lastname=@lastname,
    studyprogramid=@studyprogramid,
    dob=@dob,
    email=@email,
    phone=@phone
where
id = @id";

            cmd.Parameters.AddWithValue("@Fname", NpgsqlDbType.Text, s.FirstName);
            cmd.Parameters.AddWithValue("@Lname", NpgsqlDbType.Text, s.LastName);
            cmd.Parameters.AddWithValue("@studyprogramid", NpgsqlDbType.Integer, s.StudyProgramID);
            cmd.Parameters.AddWithValue("@dob", NpgsqlDbType.Date, s.DOB);
            cmd.Parameters.AddWithValue("@email", NpgsqlDbType.Text, s.Email);
            cmd.Parameters.AddWithValue("@phone", NpgsqlDbType.Text, s.Phone);
            cmd.Parameters.AddWithValue("@id", NpgsqlDbType.Integer, s.ID);
            { "@Fname", fname},
                { "@Lname", lname},
                { "@DoB", dob},
                { "@Email", email},
                { "@Phone", phone},
                { "@Username", username},
                { "@Password", password},
                { "@SexualOrientation", sexualOrientation},
                { "@Bio", bio},
                { "@SearchingFor", searchingFor},
                { "@Interests", interests},
                { "@Occupation", occupation},
                { "@Pictures", pictures},
                { "@Instagram", instagram ?? ""},
                { "@Snapchat", snapchat ?? ""}
            bool result = UpdateData(dbConn, cmd);
            return result;
        }

        public bool DeleteStudent(int id)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"
delete from profile
where id = @id
";

            //adding parameters in a better way
            cmd.Parameters.AddWithValue("@id", NpgsqlDbType.Integer, id);

            //will return true if all goes well
            bool result = DeleteData(dbConn, cmd);

            return result;
        }

    }
}

