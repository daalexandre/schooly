import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentsComponent } from './students/students.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CounterComponent } from './counter/counter.component';
import { StudentRegisterComponent } from './student-register/student-register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'app/shared/shared.module';

@NgModule({
  declarations: [
    HomeComponent,
    FetchDataComponent,
    CounterComponent,
    StudentsComponent,
    StudentRegisterComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SharedModule,
    RouterModule
  ],
  exports: [
    HomeComponent,
    StudentsComponent
  ]
})
export class ViewModule { }
