import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Mailer';
  showEmail: Boolean;

  constructor(){
    this.showEmail = true;
  }

  changeComponent(value: Boolean){
    this.showEmail = value;
  }
}