import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import {AuthGuard} from "./core";

const routes: Routes = [
  {
    path: 'admin-dashboard',
    loadChildren: () => import('./admin-dashboard/admin-dashboard.module')
      .then(m => m.AdminDashboardModule),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    // preload all modules; optionally we could
    // implement a custom preloading strategy for just some
    //  modules (PRs welcome 😉)
    preloadingStrategy: PreloadAllModules,
    relativeLinkResolution: 'legacy',
    onSameUrlNavigation: 'reload'
  })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
