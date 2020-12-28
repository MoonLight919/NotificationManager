import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';
import { DatasourceComponent } from '../datasource/datasource.component';

@Component({
  selector: 'app-send-email',
  templateUrl: './send-email.component.html',
  styleUrls: ['./send-email.component.css']
})
export class SendEmailComponent implements OnInit {
  subject: string;
  messageText: string;
  sendTo: string[];

  constructor(private http: HttpClient, private datasource: DatasourceComponent) {
    this.sendTo = new Array<string>();
   }

  ngOnInit() {
  }

  Post(){
    this.sendTo.splice(0, this.sendTo.length);
    for (let index = 0; index < this.datasource.Email.length; index++) {
      if(this.datasource.Email[index] == true)
        this.sendTo.push(this.datasource.data[index].email);
    }
    let body = {
      Subject: this.subject,
      MessageText: this.messageText,
      SendTo: this.sendTo
    };

    let headers: HttpHeaders = new HttpHeaders();
    headers.set('Content-Type', 'application/json');
    
    this.http.post(environment.emailApi, body, {headers: headers}).subscribe((data: any[]) => {
      console.log(data);
      alert('Sent!');
    },
      error => console.log(error));
  }
}
