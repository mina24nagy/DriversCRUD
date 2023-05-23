import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DriversListComponent } from './components/drivers/drivers-list/drivers-list.component';
import { HttpClientModule } from '@angular/common/http';
import { AddDriverComponent } from './components/drivers/add-driver/add-driver.component';
import { FormsModule } from '@angular/forms';
import { EditDriverComponent } from './components/drivers/edit-driver/edit-driver.component';
import { AlphabetizedDriverComponent } from './components/drivers/alphabetized-driver/alphabetized-driver.component';
import { BulkAddDriverComponent } from './components/drivers/bulk-add-driver/bulk-add-driver.component';

@NgModule({
  declarations: [
    AppComponent,
    DriversListComponent,
    AddDriverComponent,
    EditDriverComponent,
    AlphabetizedDriverComponent,
    BulkAddDriverComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule, 
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
