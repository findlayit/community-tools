import { Component, Input, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import {Observable, Subject} from 'rxjs/Rx';
import { FormBuilder, Validators, Control, ControlGroup, FORM_DIRECTIVES } from '@angular/common';
// Settings
import { AppSettings } from '../../../config/appSettings';
// Services
import { UserService } from '../../../services'
// interfaces
import { IRegistrationRequest } from '../../../interfaces';


@Component({
  selector: 'register',
  providers: [],
  directives: [FORM_DIRECTIVES],
  pipes: [],
  styleUrls: [],
  templateUrl: './register.template.html'
})
export class Register {
  private isLoggedIn: boolean;
  private registrationRequest: IRegistrationRequest;
  private success: boolean;

  registerForm: ControlGroup;
  firstnameControl: Control;
  lastnameControl: Control;
  emailControl: Control;
  passwordControl: Control;
  confirmpasswordControl: Control;

  constructor(public userService: UserService, public router: Router, public appSettings: AppSettings, public route: ActivatedRoute, public builder: FormBuilder) {
    this.success = false;
    // Build the form validation controls
    this.firstnameControl = new Control("", Validators.required, null);
    this.lastnameControl = new Control("", Validators.required, null);
    this.emailControl = new Control("", Validators.required, null);
    this.passwordControl = new Control("", Validators.required, null);
    this.confirmpasswordControl = new Control("", Validators.required, null);

    this.registerForm = builder.group({
      firstnameControl: this.firstnameControl,
      lastnameControl: this.lastnameControl,
      emailControl: this.emailControl,
      passwordControl: this.passwordControl,
      confirmpasswordControl: this.confirmpasswordControl
    });

    var that = this;
    this.registrationRequest = new IRegistrationRequest("Basic");

    this.isLoggedIn = this.userService.signedIn;
    this.userService.signedIn$.subscribe(data => {
      that.isLoggedIn = data;
    });
  }

  ngOnInit() {
  }

  RegisterNewUser() {
    var that = this;
    this.userService.Register(this.registrationRequest).subscribe(data => {
      that.success = true;
      that.registrationRequest = new IRegistrationRequest("Basic");
    });
  }
}
