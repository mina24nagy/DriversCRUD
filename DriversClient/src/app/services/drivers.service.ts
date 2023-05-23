import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Driver } from '../models/driver.model';

@Injectable({
  providedIn: 'root'
})
export class DriversService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  getAllDrivers(): Observable<Driver[]>{
    return this.http.get<any>(this.baseApiUrl + 'driver').pipe(map (x => {
      return x.result;
    }))};

  addDriver(addDriverRequest: Driver) : Observable<any>{
    return this.http.post<any>(this.baseApiUrl + 'driver', addDriverRequest);
  }

  getDriver(id: string) : Observable<Driver>{
    return this.http.get<any>(this.baseApiUrl + 'driver/' + id).pipe(map (x => {
      return x.result;
    }));
  }

  updateDriver(updateDriverRequest: Driver) : Observable<any>{
    return this.http.put<any>(this.baseApiUrl + 'driver', updateDriverRequest);
  }

  deleteDriver(id: number) : Observable<any>{
    return this.http.delete<any>(this.baseApiUrl + 'driver/' + id);
  }

  getAlphabetizedName(id: string) : Observable<string>{
    return this.http.get<any>(this.baseApiUrl + 'driver/alphabetized/' + id).pipe(map (x => {
      return x.result;
    }));
  }

  bulkInsert(numOfRecords: number) : Observable<any>{
    return this.http.post<any>(this.baseApiUrl + 'driver/' + numOfRecords, '');
  }
}
