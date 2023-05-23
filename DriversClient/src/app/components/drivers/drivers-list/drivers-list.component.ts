import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Driver } from 'src/app/models/driver.model';
import { DriversService } from 'src/app/services/drivers.service';

@Component({
  selector: 'app-drivers-list',
  templateUrl: './drivers-list.component.html',
  styleUrls: ['./drivers-list.component.css']
})
export class DriversListComponent implements OnInit {

  drivers: Driver[] = [];
  constructor(private driversService: DriversService, private router: Router) { }
  ngOnInit(): void {
    this.driversService.getAllDrivers()
    .subscribe({
      next: (response) => {
        this.drivers = response;
        console.log(response);
      }, 
      error: (response) => {
        //Todo: display error message to user.
        console.log(response);
      }
    });
  }

  deleteDriver(id: number) {
    this.driversService.deleteDriver(id).subscribe({
      next: (response) => {
        window.location.reload();
        console.log(response);
      }, 
      error: (response) => {
        //Todo: display error message to user.
        console.log(response);
      }
    });
  }
}
