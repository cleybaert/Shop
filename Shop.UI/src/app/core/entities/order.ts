import { IProduct } from './product';

export class OrderItem {
  product: IProduct;
  quantity: number;
  options: Map<string, string> = new Map();
}

export class Order {
  id: number;
  items: OrderItem[] = [];
}
