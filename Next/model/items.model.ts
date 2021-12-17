import { IPhoto } from "./photo.model";

export interface IItemListing {
  id: number;
  title: string;
  price: number;
  description: string;
  condition: ItemCondition;
  datePosted: any;
  archived: boolean;
  categoryName: string;
  ownerEmail: string;
  images: IPhoto[];
  errors?: any;
}

export enum ItemCondition {
  New,
  LikeNew,
  Excellent,
  Good,
  Fair,
  Salvage,
}
