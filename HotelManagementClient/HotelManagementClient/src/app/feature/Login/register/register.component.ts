import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastController } from '@ionic/angular';
import { UserService } from '../services/user.service';
import { ToastService } from 'src/app/shared/services/toast.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  public formGroup: FormGroup;

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly userService: UserService,
    private readonly toastService: ToastService
  ) {}

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      // confirmPassword: ["", Validators.required]
    });
  }

  public register() {
    if (!this.formGroup.valid) {
      this.toastService.fail();
      return;
    }

    this.userService
      .register(this.formGroup.get('email').value, this.formGroup.get('username').value, this.formGroup.get('password').value)
      .subscribe(
        (response) => {
          this.toastService.success();
        },
        (error) => {
          this.toastService.fail();
        }
      );
  }
}
