import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

export interface Customer {
  customerID: number;
  first: string;
  last: string;
  address: string;
  zip: string;
  email: string;
  phone: string;
  history: string; 

}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  CustomerList: Customer[] = [
    {
      customerID: 1,
      first: "FirstName",
      last: "LastName",
      address: "123 LaLa Lane",
      zip: "La La, LA, 54321",
      email: "email@email.com",
      phone: "5551115555",
      history: "notes and notes"
    },
    {
      customerID: 2,
      first: "AnotherFirst",
      last: "AnotherLast",
      address: "333 Boop Boop Drive",
      zip: "Beepbop, BO, 54321",
      email: "anotheremail@email.com",
      phone: "5551114321",
      history: "notes and notes and notes and notes"
    }


  ]

  constructor(private http: HttpClient) {}

  ngOnInit() {}



  title = 'customerdatabase.client';
}
