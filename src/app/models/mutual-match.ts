export interface MutualMatch {
    matchId: bigint; // Identifier for the match
    pid1: bigint;    // Profile ID of the first user
    pid2: bigint;    // Profile ID of the second user
    fname: string;
    lname?: string;
    username: string;
    pictures?: any; // Again, replace 'any' with the type you use for pictures
    // Possibly other profile information relevant to a match view
  }
  