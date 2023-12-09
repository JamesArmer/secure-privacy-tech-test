import { Routes } from '@angular/router';
import { UserListComponent } from './user-list/user-list.component';
import { CreateUserFormComponent } from './create-user-form/create-user-form.component';

export const routes: Routes = [
  { path: '', component: UserListComponent },
  { path: 'create-new-user', component: CreateUserFormComponent },
];
