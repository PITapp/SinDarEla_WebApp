/*
  This file is automatically generated. Any changes will be overwritten.
  Modify application-users.component.ts instead.
*/
import { LOCALE_ID, ChangeDetectorRef, ViewChild, AfterViewInit, Injector, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Subscription } from 'rxjs';

import { DialogService, DIALOG_PARAMETERS, DialogRef } from '@radzen/angular/dist/dialog';
import { NotificationService } from '@radzen/angular/dist/notification';
import { ContentComponent } from '@radzen/angular/dist/content';
import { HeadingComponent } from '@radzen/angular/dist/heading';
import { GridComponent } from '@radzen/angular/dist/grid';

import { ConfigService } from '../config.service';
import { AddApplicationUserComponent } from '../add-application-user/add-application-user.component';
import { EditApplicationUserComponent } from '../edit-application-user/edit-application-user.component';

import { SecurityService } from '../security.service';

export class ApplicationUsersGenerated implements AfterViewInit, OnInit, OnDestroy {
  // Components
  @ViewChild('content1') content1: ContentComponent;
  @ViewChild('pageTitle') pageTitle: HeadingComponent;
  @ViewChild('grid0') grid0: GridComponent;

  router: Router;

  cd: ChangeDetectorRef;

  route: ActivatedRoute;

  notificationService: NotificationService;

  configService: ConfigService;

  dialogService: DialogService;

  dialogRef: DialogRef;

  httpClient: HttpClient;

  locale: string;

  _location: Location;

  _subscription: Subscription;

  security: SecurityService;
  getUsersResult: any;
  parameters: any;

  constructor(private injector: Injector) {
  }

  ngOnInit() {
    this.notificationService = this.injector.get(NotificationService);

    this.configService = this.injector.get(ConfigService);

    this.dialogService = this.injector.get(DialogService);

    this.dialogRef = this.injector.get(DialogRef, null);

    this.locale = this.injector.get(LOCALE_ID);

    this.router = this.injector.get(Router);

    this.cd = this.injector.get(ChangeDetectorRef);

    this._location = this.injector.get(Location);

    this.route = this.injector.get(ActivatedRoute);

    this.httpClient = this.injector.get(HttpClient);

    this.security = this.injector.get(SecurityService);
  }

  ngAfterViewInit() {
    this._subscription = this.route.params.subscribe(parameters => {
      if (this.dialogRef) {
        this.parameters = this.injector.get(DIALOG_PARAMETERS);
      } else {
        this.parameters = parameters;
      }
      this.load();
      this.cd.detectChanges();
    });
  }

  ngOnDestroy() {
    if (this._subscription) {
      this._subscription.unsubscribe();
    }
  }


  load() {
    this.security.getUsers(null, null, null, null, null, null)
    .subscribe((result: any) => {
      this.getUsersResult = result.value;
    }, (result: any) => {

    });
  }

  grid0Add(event: any) {
    this.dialogService.open(AddApplicationUserComponent, { parameters: {}, title: 'Add Application User' });
  }

  grid0Delete(event: any) {
    this.security.deleteUser(`${event.Id}`)
    .subscribe((result: any) => {
      this.notificationService.notify({ severity: "info", summary: `Success`, detail: `User "${event.UserName}" has been deleted.` });
    }, (result: any) => {
      this.notificationService.notify({ severity: "error", summary: `Cannot delete user`, detail: `${result.error.message}` });
    });
  }

  grid0RowSelect(event: any) {
    this.dialogService.open(EditApplicationUserComponent, { parameters: {Id: event.Id}, title: 'Edit Application User' });
  }
}