using System;
using System.Text.Json.Serialization;
namespace DatingApp.Model.P
{
	public class Profile
	{
		public Profile(int id)
		{
			ID = id;
		}

        public Profile(string fname)
        {
            username = fname;
        }

        public Profile() { }

		[JsonPropertyName("pid")]
		public int ID { get; set; }
		[JsonPropertyName("fname")]
		public string fname { get; set; }
		[JsonPropertyName("lname")]
		public string lname { get; set; }
		[JsonPropertyName("dob")]
		public DateTime dob { get; set; }
		[JsonPropertyName("gender")]
		public string gender { get; set; }
		[JsonPropertyName("aol")]
		public string aol { get; set; }
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
        [JsonPropertyName("likes")]
        public int likes { get; set; }
        [JsonPropertyName("matches")]
        public int matches { get; set; }
        [JsonPropertyName("instagram")]
        public string instagram { get; set; }
        [JsonPropertyName("snapchat")]
        public string snapchat { get; set; }
    }
}

