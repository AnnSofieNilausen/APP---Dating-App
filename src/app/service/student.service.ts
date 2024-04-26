import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Student } from '../model/profile&match';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  baseUrl: string = "http://localhost:5057/api";
  constructor(private http: HttpClient) { }

  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>('http://localhost:5057/api/student');
  }

  getStudent(id: number): Observable<Student> {
    return this.http.get<Student>(`http://localhost:5057/api/student/${id}`);
  }

  deleteStudent(id: number): Observable<any> {
    return this.http.delete('http://localhost:5057/api/student/'+id);
  }

  updateStudent(student: Student): Observable<any> {
    return this.http.put('http://localhost:5057/api/student', student);
  }
}
