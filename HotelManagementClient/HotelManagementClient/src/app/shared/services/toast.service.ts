import { Injectable } from '@angular/core';
import { ToastController } from '@ionic/angular';

@Injectable({
  providedIn: 'root',
})
export class ToastService {
  constructor(private readonly toastController: ToastController) {}

  public async success() {
    const toast = await this.toastController.create({
      header: 'Success',
      message: 'Account Created',
      position: 'bottom',
      color: 'success',
      duration: 3000,
    });

    toast.present();
  }

  public async fail() {
    const toast = await this.toastController.create({
      header: 'Error',
      message: 'Something went wrong',
      position: 'bottom',
      color: 'danger',
      duration: 3000,
    });

    toast.present();
  }
}
