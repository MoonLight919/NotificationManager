import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { DatasourceComponent } from '../datasource/datasource.component';

@Component({
  selector: 'app-show-employees',
  templateUrl: './show-employees.component.html',
  styleUrls: ['./show-employees.component.css']
})
export class ShowEmployeesComponent implements OnInit {
  constructor(public datasource: DatasourceComponent) {
    // this.datasource.getData().subscribe((data: any[]) => {
    //   for (let index = 0; index < data.length; index++) {
    //     if (data[index].email)
    //       this.Email.push(true);
    //     if (data[index].telephone)
    //       this.Sms.push(true);  
    //   }
    // },
    //   error => console.log(error));;
  }

  ngOnInit() {
  }
}
