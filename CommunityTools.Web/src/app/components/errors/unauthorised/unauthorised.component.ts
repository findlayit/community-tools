import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
// Settings
import { AppSettings } from '../../../config/appSettings';


@Component({
  selector: 'unauthorised',
  providers: [],
  directives: [],
  pipes: [],
  styleUrls: ['./unauthorised.style.css'],
  templateUrl: './unauthorised.template.html'
})
export class Unauthorised {

  constructor(public router: Router, public appSettings: AppSettings, public route: ActivatedRoute) {
  }

  ngOnInit() {
  }

  redirectSignIn() {
  }
}
