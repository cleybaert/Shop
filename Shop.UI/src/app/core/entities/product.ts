import { Tag } from './tag';

export interface IProductPreview {
  thumbnail: string;
  detail: string;
}
export interface IProduct {
  id: number;
  name: string;
  description: string;
  price: number;
  url: string;
  previews: IProductPreview[];
  tags: Tag[];
}
