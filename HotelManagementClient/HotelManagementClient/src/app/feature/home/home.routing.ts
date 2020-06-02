import { Routes } from '@angular/router';
import { HomePage } from './home.page';
import { HotelAddComponent } from './component/hotel-add/hotel-add.component';

export const HomeRoutes: Routes = [
    { path: 'home', component: HomePage },
    { path: 'add-hotel', component: HotelAddComponent }
];
