using System;
using System.Text.Json.Serialization;

namespace APApiDbS2024InClass.Model
{
	public class Student
	{
		public Student(int id)
		{
			ID = id;
		}

		public Student() { }

		[JsonPropertyName("id")]
		public int ID { get; set; }
		[JsonPropertyName("firstName")]
		public string FirstName { get; set; }
		[JsonPropertyName("lastName")]
		public string LastName { get; set; }
		[JsonPropertyName("studyProgramID")]
		public int StudyProgramID { get; set; }
		[JsonPropertyName("dob")]
		public DateTime DOB { get; set; }
		[JsonPropertyName("email")]
		public string Email { get; set; }
		[JsonPropertyName("phone")]
		public string Phone { get; set; }
	}
}

