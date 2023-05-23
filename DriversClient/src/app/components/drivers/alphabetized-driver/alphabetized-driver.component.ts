import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DriversService } from 'src/app/services/drivers.service';

@Component({
  selector: 'app-alphabetized-driver',
  templateUrl: './alphabetized-driver.component.html',
  styleUrls: ['./alphabetized-driver.component.css']
})
export class AlphabetizedDriverComponent implements OnInit{
  alphabetizedName: string = '';

  constructor(private route: ActivatedRoute, private driverService: DriversService, private router: Router) {

  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id){
          this.driverService.getAlphabetizedName(id).subscribe({
            next: (response) => {
              this.alphabetizedName = response;
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
}
