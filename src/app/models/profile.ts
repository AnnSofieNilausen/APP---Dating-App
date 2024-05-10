export interface Profile {
  id: any;  // Consider using a more specific type here, such as number or string
  firstName: any;  // This should also have a more specific type, typically string
  lastName: any;  // Same as above, should be string
  pid: bigint;  // Ensure consistency in how this is used across your application
  fname: string;
  lname?: string;
  dob: Date;
  gender: string;
  aol: string;
  username: string;
  sexualOrientation: string;
  bio?: string;
  searchingFor?: string;
  interests?: string;
  occupation?: string;
  pictures?: any;  // Consider defining what 'pictures' are, such as string[]
  likes?: bigint;
  matches?: bigint;
  instagram?: string;  // Optional Instagram handle
  snapchat?: string;  // Optional Snapchat handle
}
