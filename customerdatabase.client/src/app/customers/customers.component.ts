import { Component, Input, OnInit } from '@angular/core';
import { Customer } from '../customer';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  @Input() customer: Customer = {
      customerID: 0,
      first: '',
      last: '',
      address: '',
      zip: '',
      email: '',
      phone: '',
      history: ''
  }
  constructor() { }

  ngOnInit(): void {
  }

}
