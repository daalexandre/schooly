import { StudentRegisterComponent } from './view/student-register/student-register.component';
import { ViewModule } from './view/view.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { StudentsComponent } from './view/students/students.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {
        path: 'view',
        children: [
          { path: 'students', component: StudentsComponent },
          { path: 'students/new', component: StudentRegisterComponent },
          { path: 'students/:id', component: StudentRegisterComponent },
        ]
      },
      { path: '', redirectTo: '/view/students', pathMatch: 'full' },
    ]),
    ViewModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
