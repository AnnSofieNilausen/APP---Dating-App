using System;
using System.Text.Json.Serialization;
namespace DatingApp.Model
{
	public class Profile
	{
		public Profile(int id)
		{
			ID = id;
		}

		public Profile() { }

		[JsonPropertyName("id")]
		public int ID { get; set; }
		[JsonPropertyName("firstName")]
		public string FName { get; set; }
		[JsonPropertyName("lastName")]
		public string LName { get; set; }
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

