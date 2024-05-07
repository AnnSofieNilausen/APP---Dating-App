// mutual-match.model.ts
export interface MutualMatch {
  id: number;
  userId: number;
  commonInterests: string[]; // Assuming interests are received as an array of strings
  userPhotoUrl: string;
  matchId: number; // Corrected as number type for compatibility with JSON APIs
  pid1: number;
  pid2: number;
  fname: string;
  lname?: string;
  username: string;
  pictures?: string[]; // Assuming pictures URLs are in an array of strings
  // Additional fields as required
}
