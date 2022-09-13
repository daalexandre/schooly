import { Subscription } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { Student } from 'app/core/models/student.model';
import { StudentsService } from 'app/core/services/studentes.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {
  subs = new Subscription();
  students: Student[] = [];

  constructor(private studentsService: StudentsService) { }

  ngOnInit(): void {
    this.fetch();
  }

  fetch() {
    this.studentsService.getStudents().subscribe(
      (students: Student[]) => this.students = students
    );
  }

  delete(id: number) {
    this.subs.add(this.studentsService.deleteStudent(id).subscribe(_ => this.fetch()));
  }
}
