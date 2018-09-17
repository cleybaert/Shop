import { OrderItemViewModel } from './order-item';

export class OrderViewModel {
  orders: OrderItemViewModel[] = [];
  total: number;
  shipping: number;
}
