import { Routes } from '@angular/router';
import { StudentListComponent } from './student-list/student-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EditStudentComponent } from './edit-student/edit-student.component';

export const routes: Routes = [
   { path: "students", component: StudentListComponent },
   { path: "dashboard", component: DashboardComponent },
   { path: "edit-student/:id", component: EditStudentComponent },
   { path: "**", component: StudentListComponent }
];
