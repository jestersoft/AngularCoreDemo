import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { MainMenuComponent } from './main-menu/main-menu.component';
import { ValueListComponent } from './value-list/value-list.component';

@NgModule({
    declarations: [
        AppComponent,
        MainMenuComponent,
        ValueListComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }