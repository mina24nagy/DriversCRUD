import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DriversService } from 'src/app/services/drivers.service';

@Component({
  selector: 'app-bulk-add-driver',
  templateUrl: './bulk-add-driver.component.html',
  styleUrls: ['./bulk-add-driver.component.css']
})
export class BulkAddDriverComponent implements OnInit {
  numberOfRecrods: number = 100;

  constructor(private driverService: DriversService, private router: Router) {
  }

  ngOnInit(): void {
  }

  bulkAddDrivers() {
    this.driverService.bulkInsert(this.numberOfRecrods).subscribe({
      next: (response) => {
        this.router.navigate(['/drivers']);
        console.log(response);
      }, 
      error: (response) => {
        //Todo: display error message to user.
        console.log(response);
      }
    });
  }
}
