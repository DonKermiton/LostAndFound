import {User} from './User.model';
import {Images} from './Images.model';

export interface LostModel {
  id: number;
  firstName: string;
  secondName: string;
  city?: string;
  age?: number;
  gender?: string;
  lastTimeSaw?: Date;
  nationality?: string;
  addedBy?: User;
  images?: Images[];
}
