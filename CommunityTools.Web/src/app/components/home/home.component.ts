import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
// Settings
import { AppSettings } from '../../config/appSettings';
// Components
import { Groups } from '../forums/groups/groups.component';

@Component({
  selector: 'home',
  providers: [],
  directives: [Groups],
  pipes: [],
  styleUrls: ['./home.style.css'],
  templateUrl: './home.template.html'
})
export class Home {

  constructor(public router: Router, public appSettings: AppSettings, public route: ActivatedRoute) {
  }

  ngOnInit() {
  }

}
