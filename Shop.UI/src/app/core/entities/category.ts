export class Category {
  id: number;
  name: string;
  description: string;
  banner: string;
  subCategories: Category[] = [];
}
