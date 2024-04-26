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

        public Profile(int fname)
        {
            Fname = fname;
        }

        public Profile() { }

		[JsonPropertyName("id")]
		public int ID { get; set; }
		[JsonPropertyName("FName")]
		public string FName { get; set; }
		[JsonPropertyName("LName")]
		public string LName { get; set; }
		[JsonPropertyName("dob")]
		public DateTime DOB { get; set; }
		[JsonPropertyName("email")]
		public string Email { get; set; }
		[JsonPropertyName("phone")]
		public string Phone { get; set; }
        [JsonPropertyName("username")]
        public string username { get; set; }
        [JsonPropertyName("password")]
        public string password { get; set; }
        [JsonPropertyName("sexualOrientation")]
        public string sexualOrientation { get; set; }
        [JsonPropertyName("bio")]
        public string bio { get; set; }
        [JsonPropertyName("searchingFor")]
        public string searchingFor { get; set; }
        [JsonPropertyName("interests")]
        public string interests { get; set; }
        [JsonPropertyName("occupation")]
        public string occupation { get; set; }
        [JsonPropertyName("pictures")]
        public string pictures { get; set; }
        [JsonPropertyName("instagram")]
        public string instagram { get; set; }
        [JsonPropertyName("snapchat")]
        public string snapchat { get; set; }
    }
}

