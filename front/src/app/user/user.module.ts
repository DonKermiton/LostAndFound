import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LostPersonComponent } from './components/dashboard/lost-person/lost-person.component';
import { CreateComponent } from './components/create/create.component';


@NgModule({
  declarations: [
    DashboardComponent,
    LostPersonComponent,
    CreateComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule
  ]
})
export class UserModule { }
