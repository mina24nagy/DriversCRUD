import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DriversListComponent } from './components/drivers/drivers-list/drivers-list.component';
import { AddDriverComponent } from './components/drivers/add-driver/add-driver.component';
import { EditDriverComponent } from './components/drivers/edit-driver/edit-driver.component';
import { AlphabetizedDriverComponent } from './components/drivers/alphabetized-driver/alphabetized-driver.component';
import { BulkAddDriverComponent } from './components/drivers/bulk-add-driver/bulk-add-driver.component';

const routes: Routes = [
  {
    path: '',
    component: DriversListComponent
  },
  {
    path: 'drivers',
    component: DriversListComponent
  },
  {
    path: 'drivers/add',
    component: AddDriverComponent
  },
  {
    path: 'drivers/edit/:id',
    component: EditDriverComponent
  }, 
  {
    path: 'drivers/alphabetized/:id',
    component: AlphabetizedDriverComponent
  }, 
  {
    path: 'drivers/bulkdAdd',
    component: BulkAddDriverComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
