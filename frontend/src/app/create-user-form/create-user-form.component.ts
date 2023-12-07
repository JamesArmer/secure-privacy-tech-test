import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  NonNullableFormBuilder,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { UserApiService } from '../user-api.service';
import { User } from '../models/user';

@Component({
  selector: 'app-create-user-form',
  standalone: true,
  templateUrl: './create-user-form.component.html',
  imports: [ReactiveFormsModule],
})
export class CreateUserFormComponent {
  userForm: FormGroup;

  constructor(
    private readonly formBuilder: NonNullableFormBuilder,
    private readonly userApiService: UserApiService
  ) {
    this.userForm = this.formBuilder.group({
      name: ['', Validators.required],
      email: ['', Validators.required],
      phoneNumber: ['', [Validators.required, Validators.minLength(10)]],
    });
  }

  onSubmit() {
    const user = new User(this.userForm.value);
    this.userApiService.createNewUser(user);
  }
}
