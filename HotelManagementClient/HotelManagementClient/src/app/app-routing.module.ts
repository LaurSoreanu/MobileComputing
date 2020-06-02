import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { UserRoutes } from './feature/Login/user.routes';
import { HomeRoutes } from './feature/home/home.routing';

const routes: Routes = [...UserRoutes, ...HomeRoutes];

@NgModule({
  imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
