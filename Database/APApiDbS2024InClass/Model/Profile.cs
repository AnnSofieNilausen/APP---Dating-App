using System;
using System.Text.Json.Serialization;
namespace APApiDbS2024InClass.Model
{
	public class Profile
	{
		public Profile(int id)
		{
			ID = id;
		}

		public Profile() { }

		[JsonPropertyName("Pid")]
		public int Pid { get; set; }
		[JsonPropertyName("FName")]
		public string FName { get; set; }
		[JsonPropertyName("LName")]
		public string LName { get; set; }
		[JsonPropertyName("dob")]
		public DateTime DOB { get; set; }
		[JsonPropertyName("email")]
		public string Email { get; set; }
		[JsonPropertyName("Gender")]
		public string Gender { get; set; }
        [JsonPropertyName("AoL")]
        public string AoL { get; set; }
        [JsonPropertyName("Username")]
        public string Username { get; set; }
        [JsonPropertyName("Sexual_Orientation")]
        public string Sexual_Orientation { get; set; }
        [JsonPropertyName("Bio")]
        public string Bio { get; set; }
        [JsonPropertyName("Searching_For")]
        public string Searching_For { get; set; }
        [JsonPropertyName("Interests")]
        public string Interests { get; set; }
        [JsonPropertyName("Occupation")]
        public string Occupation { get; set; }
        [JsonPropertyName("Pictures")]
        public string Pictures { get; set; }
        [JsonPropertyName("Likes")]
        public string Likes { get; set; }
        [JsonPropertyName("Matches")]
        public string Matches { get; set; }
    }
}

