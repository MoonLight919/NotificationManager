import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import { RouterModule } from '@angular/router';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShowEmployeesComponent } from './show-employees/show-employees.component';
import { DatasourceComponent } from './datasource/datasource.component';
import { routes } from "./routes";
import { SendSmsComponent } from './send-sms/send-sms.component';
import { SendEmailComponent } from './send-email/send-email.component';

@NgModule({
  declarations: [
    AppComponent,
    ShowEmployeesComponent,
    DatasourceComponent,
    SendSmsComponent,
    SendEmailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(routes),
    FormsModule,
    HttpClientModule
  ],
  providers: [DatasourceComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
