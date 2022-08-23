import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { catchError,retry } from 'rxjs/operators';
import { EMPTY } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TriangleService {

  createTriangleUrl = 'https://localhost:7064/api/Gateway/CreateHaromszog';
  updateTriangleUrl = 'https://localhost:7064/api/Gateway/GetHaromszog'
  getAllProcessUrl = 'https://localhost:7064/api/Gateway/GetAllProcess';
  shutDownProcessUrl='https://localhost:7064/api/Gateway/ShutDownProcess';
  port = 8000;
  constructor(private http: HttpClient) { }

  getNewCoordinates(guid: string, width: number, height: number): Observable<Triangle> {
    return this.http.get<Triangle>(this.updateTriangleUrl + '?guid=' + guid + '&screenWidth=' + width + '&screenHeight=' + height);
  }

  createTriangle(guid: string, width: number, height: number): Observable<Triangle> {
    return this.http.post<Triangle>(this.createTriangleUrl + '?guid=' + guid + '&port=' + (this.port++) + '&screenWidth=' + width + '&screenHeight=' + height, null);
  }
  getAllProcess():Observable<Processes[]> {
    return this.http.get<Processes[]>(this.getAllProcessUrl);
  }

  getAllProcesses(){
   return this.getAllProcess();
  }
  generateGuid(): string {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
      var r = Math.random() * 16 | 0,
        v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }
}

export interface Triangle {
  guid: string;
  port: number;
  pont1: Point;
  pont2: Point;
  pont3: Point;
  color: string;
}
export interface Point {
  x: number;
  y: number;
}

export interface Processes{
  guid:string;
  process:ProcessModel;
}
export interface ProcessModel{
  port:number;
  isrun:boolean;
}