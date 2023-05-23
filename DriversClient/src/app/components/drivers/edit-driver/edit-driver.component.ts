import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Driver } from 'src/app/models/driver.model';
import { DriversService } from 'src/app/services/drivers.service';

@Component({
  selector: 'app-edit-driver',
  templateUrl: './edit-driver.component.html',
  styleUrls: ['./edit-driver.component.css']
})
export class EditDriverComponent implements OnInit {

  driverDetails: Driver = {
    id: 0, 
    firstName: '',
    lastName: '',
    phoneNumber: '',
    email: ''
  };
  
  constructor(private route: ActivatedRoute, private driverService: DriversService, private router: Router) {

  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id){
          this.driverService.getDriver(id).subscribe({
            next: (response) => {
              this.driverDetails = response;
            },
            error: (response) => {
              //Todo: display error message to user.
              console.log(response);
            }
          });
        }
      } 

    })
  }

  updateDriver() {
    this.driverService.updateDriver(this.driverDetails).subscribe({
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
