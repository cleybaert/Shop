import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';

@Injectable({
  providedIn: 'root'
})
export class ProductDataService implements InMemoryDbService {
  createDb() {
    let products = [
      { id: 1, name: 'Zomerkleedje', description: 'Kort kleedje voor in de zomer' },
      { id: 2, name: 'Broek', description: 'Jeans broek'},
      { id: 3, name: 'Slaapzak', description: 'Lichte slaapzak' },
      { id: 4, name: 'Pull', description: 'Wollen pull met bloemenmotief' }
    ];
    return {products};
  }

  constructor() { }
}
