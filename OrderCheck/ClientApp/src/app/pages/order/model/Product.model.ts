import { ProductType } from "../../../shared-models/enum/product-type.enum";

export class ProductModel {
  id: string;
  name: string;
  description: string;
  price: number;
  type: ProductType;
}
