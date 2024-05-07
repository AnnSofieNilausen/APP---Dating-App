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

        public Profile(int id, string username1)
        {
            ID = id;
            Username = username1;
        }

        public Profile() { }

		[JsonPropertyName("pid")]
		public int ID { get; set; }
		[JsonPropertyName("Fname")]
		public string? Fname { get; set; }
		[JsonPropertyName("Lname")]
		public string? Lname { get; set; }
		[JsonPropertyName("Dob")]
		public DateTime? Dob { get; set; }
		[JsonPropertyName("Gender")]
		public string? Gender { get; set; }
		[JsonPropertyName("Aol")]
		public string? Aol { get; set; }
        [JsonPropertyName("Username")]
        public string? Username { get; set; }
        [JsonPropertyName("Sexualorientation")]
        public string? Sexualorientation { get; set; }
        [JsonPropertyName("Bio")]
        public string? Bio { get; set; }
        [JsonPropertyName("Searchingfor")]
        public string? Searchingfor { get; set; }
        [JsonPropertyName("Interests")]
        public string? Interests { get; set; }
        [JsonPropertyName("Occupation")]
        public string? Occupation { get; set; }
        [JsonPropertyName("Pictures")]
        public string? Pictures { get; set; }
        [JsonPropertyName("Likes")]
        public int? Likes { get; set; }
        [JsonPropertyName("Matches")]
        public int? Matches { get; set; }
        [JsonPropertyName("Instagram")]
        public string? Instagram { get; set; }
        [JsonPropertyName("Snapchat")]
        public string? Snapchat { get; set; }
    }
}

