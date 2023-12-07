import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-user-form',
  standalone: true,
  templateUrl: './create-user-form.component.html',
  imports: [ReactiveFormsModule],
})
export class CreateUserFormComponent {
  userForm = this.formBuilder.group({
    nameControl: ['', Validators.required],
    emailControl: ['', Validators.required],
    phoneNumberControl: ['', Validators.required],
  });

  constructor(private formBuilder: FormBuilder) {}

  onSubmit() {}
}
