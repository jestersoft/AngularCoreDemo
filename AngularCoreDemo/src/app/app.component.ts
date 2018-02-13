import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private _httpService: Http) { }

  apiValues: string[] = [];
  menuValues: string[] = [];
  title = "Angular with .Net Core - Demo";
  ngOnInit() {
    this._httpService.get('/api/values').subscribe(values => {
      this.apiValues = values.json() as string[];
    });

    this._httpService.get('/api/menu').subscribe(values => {
      this.menuValues = values.json() as string[];
    });
  }
}
