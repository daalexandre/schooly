import { Component, HostBinding, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EducationLevel } from 'app/core/enums/education-level.enum';
import { StudentsService } from 'app/core/services/studentes.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-student-register',
  templateUrl: './student-register.component.html',
  styleUrls: ['./student-register.component.css']
})
export class StudentRegisterComponent implements OnInit, OnDestroy {
  subs = new Subscription();
  educationLevel = EducationLevel;
  studentId = 0;

  studentForm = this.fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    educationLevelId: [0],
    birthDate: ['', Validators.required]
  })

  constructor(
    private fb: FormBuilder,
    private studentService: StudentsService,
    private route: ActivatedRoute,
    private router: Router

  ) { }

  ngOnDestroy(): void {
    this.subs.unsubscribe()
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.studentId = params.id;
      this.loadStudent(params.id);
    });
  }

  loadStudent(id: number) {
    if (id == null) return;
    this.studentService.getStudentById(id).subscribe(
      student => this.studentForm.patchValue(student)
    )
  }

  goBack() {
    this.router.navigate(['/view/students'], { relativeTo: this.route });
  }

  onSubmit() {
    if (this.studentId) {
      this.subs.add(this.studentService.updateStudent(this.studentId, this.studentForm.value).subscribe(_ => this.goBack()));
    }
    else {
      this.subs.add(this.studentService.saveStudent(this.studentForm.value).subscribe(_ => this.goBack()));
    }

  }
}
