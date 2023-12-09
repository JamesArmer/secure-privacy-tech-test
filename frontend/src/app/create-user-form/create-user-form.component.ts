import { Component } from '@angular/core';
import {
  FormGroup,
  NonNullableFormBuilder,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { UserApiService } from '../user-api.service';
import { User } from '../models/user';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-create-user-form',
  standalone: true,
  templateUrl: './create-user-form.component.html',
  imports: [ReactiveFormsModule, RouterModule],
})
export class CreateUserFormComponent {
  userForm: FormGroup;

  constructor(
    private readonly formBuilder: NonNullableFormBuilder,
    private readonly userApiService: UserApiService,
    private router: Router
  ) {
    this.userForm = this.formBuilder.group({
      name: ['', Validators.required],
      email: ['', Validators.required],
      phoneNumber: ['', [Validators.required, Validators.minLength(10)]],
    });
  }

  async onSubmit() {
    const user = new User(this.userForm.value);
    await this.userApiService.createNewUser(user);
    this.router.navigate(['']);
  }
}
