export type OrderItem = {
  id?: number;
  orderId: number;
  menuId: number;
  menuItemId: number;
  quantity: number;
  comment?: string;
};
