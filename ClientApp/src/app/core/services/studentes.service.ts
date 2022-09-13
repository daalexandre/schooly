import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from '../models/student.model';
import { catchError, Observable, of } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  url!: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
    this.url = `${this.baseUrl}students`;
  }

  getStudents() {
    return this.http.get<Student[]>(this.url);
  }

  getStudentById(id: number) {
    return this.http.get<Student[]>(`${this.url}/${id}`);
  }

  saveStudent(student: Student) {
    return this.http.post<any>(this.url, student).pipe(
      catchError(this.handleError<Student>('addStudent', student))
    );
  }

  updateStudent(id:number, student: Student) {
    return this.http.put<any>(`${this.url}/${id}`, student).pipe(
      catchError(this.handleError<Student>('updateStudent', student))
    );
  }

  deleteStudent(id:number) {
    return this.http.delete<any>(`${this.url}/${id}`).pipe(
      catchError(this.handleError<Student>('deleteStudent'))
    );
  }



  private handleError<T>(operation = '', result?: T) {
    return (error: any): Observable<T> => {
      console.error(operation, error, result || {});
      return of(result as T);
    };
  }
}
