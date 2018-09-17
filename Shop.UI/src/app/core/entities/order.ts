export class OrderItem {
  productid: number;
  quantity: number;
  options: Map<string, string> = new Map();
}

export class Order {
  id: number;
  items: OrderItem[] = [];
}
