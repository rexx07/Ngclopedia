import {NgModule} from "@angular/core";
import {FaIconLibrary, FontAwesomeModule} from "@fortawesome/angular-fontawesome";

import {SidebarComponent} from "./sidebar";
import {AdminDashboardRoutingModule} from "./admin-dashboard-routing.module";
import {AdminDashboardResolver} from "./admin-dashboard-resolver";
import {AdminDashboardComponent} from "./admin-dashboard.component";
import {faTimes} from "@fortawesome/free-solid-svg-icons/faTimes";
import { NavbarComponent } from './navbar/navbar.component';
import {faUser} from "@fortawesome/free-solid-svg-icons/faUser";
import {faCog} from "@fortawesome/free-solid-svg-icons/faCog";
import {faBell} from "@fortawesome/free-solid-svg-icons/faBell";
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [
    SidebarComponent,
    AdminDashboardComponent,
    NavbarComponent,
    FooterComponent,
  ],
  imports: [
    FontAwesomeModule,
    AdminDashboardRoutingModule
  ],
  exports: [
  ],
  providers: [
    //AdminDashboardResolver
  ]
})
export class AdminDashboardModule{
  constructor(library: FaIconLibrary) {
    library.addIcons(
      faTimes,
      faUser,
      faCog,
      faBell
    );
  }
}
