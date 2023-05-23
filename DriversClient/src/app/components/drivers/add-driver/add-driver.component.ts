import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Driver } from 'src/app/models/driver.model';
import { DriversService } from 'src/app/services/drivers.service';

@Component({
  selector: 'app-add-driver',
  templateUrl: './add-driver.component.html',
  styleUrls: ['./add-driver.component.css']
})
export class AddDriverComponent implements OnInit {
  addDriverRequest: Driver = {
    id: 0, 
    firstName: '',
    lastName: '',
    phoneNumber: '',
    email: ''
  };

  constructor(private driverService: DriversService, private router: Router) {

  }

  ngOnInit(): void {
    
  }

  addDriver() {
    this.driverService.addDriver(this.addDriverRequest).subscribe({
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
