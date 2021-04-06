import {Component, Input, OnInit} from '@angular/core';
import {LostModel} from '../../../../share/models/Lost.model';

@Component({
  selector: 'app-lost-person',
  templateUrl: './lost-person.component.html',
  styleUrls: ['./lost-person.component.scss']
})
export class LostPersonComponent implements OnInit {

  @Input() lost: LostModel;

  constructor() {
  }

  ngOnInit(): void {
    console.log(this.lost);
  }

}
