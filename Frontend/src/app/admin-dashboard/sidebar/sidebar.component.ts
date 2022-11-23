import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {BehaviorSubject, distinctUntilChanged, Observable} from "rxjs";

@Component({
  selector: 'app-admin-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  constructor() {
  }
  ngOnInit() {
  }
}
