import { Component, Input, OnInit } from '@angular/core';
import { StudentService } from '../service/student.service';
import { Student } from '../model/profile&match';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

import { MatDatepickerModule} from '@angular/material/datepicker';
import { provideNativeDateAdapter} from '@angular/material/core';

@Component({
  selector: 'app-edit-student',
  standalone: true,
  providers: [provideNativeDateAdapter()],
  imports: [MatDatepickerModule, ReactiveFormsModule, MatButtonModule, MatFormFieldModule, MatInputModule, FormsModule],
  templateUrl: './edit-student.component.html',
  styleUrl: './edit-student.component.css'
})
export class EditStudentComponent implements OnInit {
  @Input() id!: number;
  student!: Student;


  firstNameFormControl: FormControl = new FormControl('', [Validators.required])
  lastNameFormControl: FormControl = new FormControl('', [Validators.required])
  studyProgramIDFormControl: FormControl = new FormControl('', [Validators.required])
  dobFormControl: FormControl = new FormControl('', [Validators.required]);

  studentFormGroup: FormGroup = new FormGroup({
    firstName: this.firstNameFormControl,
    lastName: this.lastNameFormControl,
    studyProgramID: this.studyProgramIDFormControl,
    dobFormControl: this.dobFormControl
  });

  constructor(private studentService: StudentService, private router: Router) {

  }

  ngOnInit() {
    this.studentService.getStudent(this.id).subscribe((student) => {
      this.student = student;
    });
  }

  updateStudent() {
    if (this.studentFormGroup.valid) {
      this.studentService.updateStudent(this.student).subscribe(() => {
        this.router.navigate(["students"])
      });
    }
    else {
      console.log('Form is invalid. Please check all values');
    }
  }
}
