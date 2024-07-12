import { Component } from '@angular/core';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css',
})
export class ProductListComponent {
  name: string = 'iPhone15';
  addToCart: number = 0;
  price: number = 1000;
  color: string = 'platinum-black';
  discount: number = 20;
  inStock: number = 10;
  e_name: string = '';
  wlcm: string = 'Welcome ';
  product = {
    name: 'iPhone14',
    addToCart: 0,
    price: 100,
    color: 'red',
    discount: 10,
    inStock: 8,
    e_name: '',
    image1: 'assets/images/iPhone.png',
    image2: 'assets/images/image2.png',
    finalPrice() {
      return this.price - this.price * (this.discount / 100);
    },
  };

  finalPrice() {
    return this.price - this.price * (this.discount / 100);
  }
  onNameChange(event: any) {
    this.e_name = this.wlcm + event.target.value;
  }
  dcmCartValue() {
    if (this.addToCart > 0) {
      this.addToCart--;
    }
  }
  incCartValue() {
    if (this.addToCart < this.inStock) {
      this.addToCart++;
    }
  }
}
