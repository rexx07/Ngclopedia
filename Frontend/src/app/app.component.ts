import {Component, OnInit} from '@angular/core';
import {AuthService} from "./core";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'ngclopedia';
  searchText: string = '';

  constructor(
    private authService: AuthService) {
  }

  ngOnInit() {
    this.authService.populate();
  }

  onSearchTextEntered(searchValue: any){
    this.searchText = searchValue;
    //this.apiService.getData()
  }
}
