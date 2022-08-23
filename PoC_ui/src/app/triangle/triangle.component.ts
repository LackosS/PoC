import { Component, OnInit } from '@angular/core';
import { Triangle, TriangleService } from '../services/triangle.service';
import { interval } from 'rxjs';

@Component({
  selector: 'triangle',
  templateUrl: './triangle.component.html',
  styleUrls: ['./triangle.component.scss']
})
export class TriangleComponent implements OnInit {

  triangles: any[] = [];
  width = window.innerWidth;
  height = window.innerHeight;
  guid = '';
  points: string = '';
  constructor(private triangleService: TriangleService) {

  }

  updateTriangle(guid: string, width: number, height: number) {
    var founded = this.triangles.find(item => item.guid == guid);
    var index = this.triangles.findIndex(item => item.guid == founded.guid);
    this.triangleService.getNewCoordinates(guid, width, height).subscribe((res) => {
      if(res.pont1==null || res.pont2==null || res.pont3==null){
        return;
      }
      this.triangles[index].pont1 = res.pont1;
      this.triangles[index].pont2 = res.pont2;
      this.triangles[index].pont3 = res.pont3;
      this.triangles[index].color = res.color;
    });
  }

  createTriangle(guid: string, width: number, height: number) {
    guid = this.guid = this.generateGuid();
    this.triangleService.createTriangle(guid, width, height).subscribe(res => {
      this.triangles.push(res);
      this.triangleService.getAllProcess();
    });
    
  }

  generateTrianglePoints(triangle: Triangle): string {
    return this.points = triangle.pont1.x + ',' + triangle.pont1.y + " " + triangle.pont2.x + ',' + triangle.pont2.y + " " + triangle.pont3.x + ',' + triangle.pont3.y;
  }

  generateGuid() {
    return this.triangleService.generateGuid();
  }
  updateHelper() {
    if (this.triangles.length == 0) return;
    for (let item of this.triangles) {
      this.updateTriangle(item.guid, this.width, this.height);
    }
  }
  ngOnInit(): void {
    const updatePeriod = interval(150);
    updatePeriod.subscribe(val => this.updateHelper());
  }
}
