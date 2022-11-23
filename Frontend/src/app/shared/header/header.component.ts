import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import {AuthService} from "../../core";

@Component({
  selector: 'app-navbar',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  @Output() searchTextChanged: EventEmitter<string> = new EventEmitter<string>();

  enteredSearchValue: string = '';

  constructor(private authService: AuthService){}

  ngOnInit(): void {
  }

  onSearchTextChanged(){
    this.searchTextChanged.emit(this.enteredSearchValue);
  }



}
