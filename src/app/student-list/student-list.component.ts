import { Component, OnInit } from '@angular/core';
import { Student } from '../model/profile&match';
import { StudentComponent } from '../student/student.component';
import { StudentService } from '../service/student.service';


@Component({
    selector: 'app-student-list',
    standalone: true,
    templateUrl: './student-list.component.html',
    styleUrl: './student-list.component.css',
    imports: [StudentComponent]
})
export class StudentListComponent implements OnInit {
    constructor(private studentService: StudentService) {}

    studentList: Student[] = [];

    ngOnInit(): void {
        this.studentService.getStudents().subscribe((students) => {
            this.studentList = students;
        });
    }
}
