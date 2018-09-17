export interface IProductPreview {
  thumbnail: string;
  detail: string;
}
export interface IProduct {
  id: number;
  name: string;
  description: string;
  price: number;
  availableSizes: string[];
  url: string;
  previews: IProductPreview[];
}
