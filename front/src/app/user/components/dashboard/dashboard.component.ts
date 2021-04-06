import {Component, OnInit} from '@angular/core';
import {LostModel} from '../../../share/models/Lost.model';
import {LostService} from '../../services/lost.service';
import {flatMap} from 'rxjs/operators';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  LostPeople: LostModel[] = [];

  constructor(private lostService: LostService) {
  }

  ngOnInit(): void {
    this.getNextLost();
  }

  getNextLost(): void {
    this.lostService.getNextLostPeople(10, this.LostPeople.length)
      .pipe(
        flatMap((lost) => lost)
      )
      .subscribe(lost => {
        this.LostPeople.push(lost);
      });
  }


}
