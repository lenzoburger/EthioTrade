import { Avatar } from './avatar';
import { Listing } from './listing';
import { Address } from './address';

export interface UserListing {
  id: number;
  username: string;
  email: string;
  firstname: string;
  lastname: string;
  dateOfBirth: string;
  gender: string;
  phone: string;
  physicalAddress: Address;
  lastActiveDate: string;
  createdDate: string;
  bio: string;
  interests: string;
  avatarUrl: string;
  avatar: Avatar;
  myListings: Listing[];
}
