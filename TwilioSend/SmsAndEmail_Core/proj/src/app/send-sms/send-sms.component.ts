import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';
import { DatasourceComponent } from '../datasource/datasource.component';

@Component({
  selector: 'app-send-sms',
  templateUrl: './send-sms.component.html',
  styleUrls: ['./send-sms.component.css']
})
export class SendSmsComponent implements OnInit {
  messageText: string;
  sendTo: string[];

  constructor(private http: HttpClient, private datasource: DatasourceComponent) {
    this.sendTo = new Array<string>();
   }

  ngOnInit() {
  }

  Post(){
    this.sendTo.splice(0, this.sendTo.length);
    for (let index = 0; index < this.datasource.Sms.length; index++) {
      if(this.datasource.Sms[index] == true)
        this.sendTo.push(this.datasource.data[index].telephone);
    }
    let body = {
      MessageText: this.messageText,
      SendTo: this.sendTo
    };

    let headers: HttpHeaders = new HttpHeaders();
    headers.set('Content-Type', 'application/json');
    
    this.http.post(environment.smsApi, body, {headers: headers}).subscribe((data: any[]) => {
      console.log(data);
      alert('Sent!');
    },
      error => console.log(error));
  }

}
