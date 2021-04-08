import { Component, OnInit } from '@angular/core';
import {UserService} from '../../../core/services/user.service';

@Component({
  selector: 'app-layout-logged',
  templateUrl: './layout-logged.component.html',
  styleUrls: ['./layout-logged.component.scss']
})
export class LayoutLoggedComponent implements OnInit {

  constructor(public userService: UserService) { }

  ngOnInit(): void {
    this.userService.loggedUser.subscribe((user) => {
      console.log(user);
    });
  }

}
