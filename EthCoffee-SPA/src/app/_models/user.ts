import { Avatar } from './avatar';
import { Address } from './address';

export interface User {
    id: number;
    username: string;
    email: string;
    firstname: string;
    lastname: string;
    dateOfBirth?: string;
    gender?: string;
    phone?: string;
    physicalAddress?: Address;
    lastActiveDate: string;
    createdDate: string;
    avatarUrl?: string;
    avatar?: Avatar;
}
