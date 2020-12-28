import { Component, OnInit, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';
import { Employee } from './employee';

@Component({
  selector: 'app-datasource',
  templateUrl: './datasource.component.html',
  styleUrls: ['./datasource.component.css']
})
@Injectable()
export class DatasourceComponent implements OnInit {
  data: Employee[];
  Sms: boolean[];
  Email: boolean[];
  
  constructor(private http: HttpClient) {
    this.data = new Array<Employee>();
    this.getData().subscribe((data: any[]) => {
      this.data = data;
      this.Email = new Array<boolean>(this.data.length);
      this.Sms = new Array<boolean>(this.data.length);
      //this.Email.fill(true);
    },
      error => console.log(error));;
   }

   getData(){
    return this.http.get(environment.employeeApi);
   }

  ngOnInit() {
  }

}
