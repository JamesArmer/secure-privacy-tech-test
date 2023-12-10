import { Routes } from '@angular/router';
import { UserListComponent } from './user-list/user-list.component';
import { CreateUserFormComponent } from './create-user-form/create-user-form.component';
import { PrivacyPolicyComponent } from './privacy-policy/privacy-policy.component';

export const routes: Routes = [
  { path: '', component: UserListComponent },
  { path: 'create-new-user', component: CreateUserFormComponent },
  { path: 'privacy-policy', component: PrivacyPolicyComponent },
];
