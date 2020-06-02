import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { ToastService } from 'src/app/shared/services/toast.service';
import { NativeStorage } from '@ionic-native/native-storage/ngx';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  public loginGroup: FormGroup;

  private key = "token";

  constructor(private readonly formBuilder: FormBuilder, private loginService: UserService, private router: Router,
    private readonly toastService: ToastService, private nativeStorage: NativeStorage) {}

  ngOnInit() {
    this.loginGroup = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  public login() {
    this.loginService.login(this.loginGroup.get('username').value, this.loginGroup.get('password').value).subscribe(
      (response) => {
        localStorage.setItem(this.key, response.token);
        // this.loading = false;
        this.nativeStorage.setItem(this.key, response.token);
        this.router.navigate(['/home']);
      },
      (error) => {
        // this.loading = false;
        this.toastService.fail();
      }
    );
  }
}
