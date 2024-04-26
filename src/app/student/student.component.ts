import { Component, Input } from '@angular/core';
import { Student } from '../model/profile&match';
import { StudentService } from '../service/student.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student',
  standalone: true,
  imports: [],
  templateUrl: './student.component.html',
  styleUrl: './student.component.css'
})
export class StudentComponent {
  @Input() student!: Student;

  constructor(private studentService: StudentService, private router: Router) {}

  deleteStudent(id: number) {
    this.studentService.deleteStudent(id).subscribe();
  }

  updateStudent(id: number) {
    this.router.navigate(["edit-student", id])
  }
}
