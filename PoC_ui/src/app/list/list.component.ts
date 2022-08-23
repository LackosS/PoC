import { Component, OnInit } from '@angular/core';
import { TriangleService } from '../services/triangle.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  processes: any[] = [];

  constructor(private triangleService: TriangleService) { }

  ngOnInit(): void {
  }
  getAllProcesses() {
    this.triangleService.getAllProcesses().subscribe(res => this.processes=res);
  }
}
