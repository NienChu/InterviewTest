import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductType } from '../../../shared-models/enum/product-type.enum';
import { ProductService } from '../../../shared-services/api-service/product.service';
import { ProductModel } from '../model/Product.model';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

  id: string;
  product: ProductModel;

  productType = ProductType;

  constructor(private productService: ProductService,
    private activateRoute: ActivatedRoute) {
    this.activateRoute.params.subscribe(parms => {
      if (parms['id']) {
        this.id = parms['id'];
        this.getProductDetail();
      }
    });
  }

  ngOnInit(): void {
  }

  private getProductDetail() {
    this.productService.getProdetail(this.id)
      .subscribe(res => {
        this.product = res;
      });
  }

}
