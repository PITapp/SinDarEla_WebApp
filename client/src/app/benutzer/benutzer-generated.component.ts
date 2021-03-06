/*
  This file is automatically generated. Any changes will be overwritten.
  Modify benutzer.component.ts instead.
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
import { TabsComponent } from '@radzen/angular/dist/tabs';
import { GridComponent } from '@radzen/angular/dist/grid';
import { ButtonComponent } from '@radzen/angular/dist/button';
import { TemplateFormComponent } from '@radzen/angular/dist/template-form';
import { LabelComponent } from '@radzen/angular/dist/label';
import { TextBoxComponent } from '@radzen/angular/dist/textbox';
import { RequiredValidatorComponent } from '@radzen/angular/dist/required-validator';
import { FormComponent } from '@radzen/angular/dist/form';

import { ConfigService } from '../config.service';
import { AddApplicationRoleComponent } from '../add-application-role/add-application-role.component';
import { BenutzerNeuComponent } from '../benutzer-neu/benutzer-neu.component';
import { BenutzerBearbeitenComponent } from '../benutzer-bearbeiten/benutzer-bearbeiten.component';

import { DbSinDarElaService } from '../db-sin-dar-ela.service';
import { SecurityService } from '../security.service';

export class BenutzerGenerated implements AfterViewInit, OnInit, OnDestroy {
  // Components
  @ViewChild('content1') content1: ContentComponent;
  @ViewChild('heading8') heading8: HeadingComponent;
  @ViewChild('heading9') heading9: HeadingComponent;
  @ViewChild('heading16') heading16: HeadingComponent;
  @ViewChild('tabs0') tabs0: TabsComponent;
  @ViewChild('gridUsers') gridUsers: GridComponent;
  @ViewChild('grid0') grid0: GridComponent;
  @ViewChild('formBenutzer') formBenutzer: TemplateFormComponent;
  @ViewChild('BenutzernameLabel') benutzernameLabel: LabelComponent;
  @ViewChild('Benutzername') benutzername: TextBoxComponent;
  @ViewChild('BenutzernameRequiredValidator') benutzernameRequiredValidator: RequiredValidatorComponent;
  @ViewChild('KennwortLabel') kennwortLabel: LabelComponent;
  @ViewChild('Kennwort') kennwort: TextBoxComponent;
  @ViewChild('KennwortRequiredValidator') kennwortRequiredValidator: RequiredValidatorComponent;
  @ViewChild('InitialenLabel') initialenLabel: LabelComponent;
  @ViewChild('Initialen') initialen: TextBoxComponent;
  @ViewChild('InitialenRequiredValidator') initialenRequiredValidator: RequiredValidatorComponent;
  @ViewChild('BenutzerInfoLabel') benutzerInfoLabel: LabelComponent;
  @ViewChild('BenutzerInfo') benutzerInfo: TextBoxComponent;
  @ViewChild('EMailLabel') eMailLabel: LabelComponent;
  @ViewChild('EMail') eMail: TextBoxComponent;
  @ViewChild('button2') button2: ButtonComponent;
  @ViewChild('button3') button3: ButtonComponent;
  @ViewChild('form0') form0: FormComponent;
  @ViewChild('grid2') grid2: GridComponent;

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

  dbSinDarEla: DbSinDarElaService;

  security: SecurityService;
  rstRoles: any;
  parameters: any;
  rstUsers: any;
  rstUsersAusgew??hlt: any;
  rstBenutzer: any;

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

    this.dbSinDarEla = this.injector.get(DbSinDarElaService);
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
    this.gridUsers.load();

    this.security.getRoles(null, null, null, null, null, null)
    .subscribe((result: any) => {
      this.rstRoles = result.value;
    }, (result: any) => {

    });
  }

  gridUsersAdd(event: any) {
    this.dialogService.open(BenutzerNeuComponent, { parameters: {}, title: `Neuer Benutzer` });
  }

  gridUsersDelete(event: any) {
    this.security.deleteUser(`${event.Id}`)
    .subscribe((result: any) => {
      this.notificationService.notify({ severity: "info", summary: `Success`, detail: `User "${event.UserName}" has been deleted.` });
    }, (result: any) => {
      this.notificationService.notify({ severity: "error", summary: `Cannot delete user`, detail: `${result.error.message}` });
    });
  }

  gridUsersLoadData(event: any) {
    this.security.getUsers(null, null, null, null, null, null)
    .subscribe((result: any) => {
      this.rstUsers = result.value;
    }, (result: any) => {

    });
  }

  gridUsersRowSelect(event: any) {
    this.rstUsersAusgew??hlt = event;

    this.dbSinDarEla.getBenutzers(`AspNetUsers_Id eq '${event.Id}'`, null, null, null, null, null, null, null)
    .subscribe((result: any) => {
      this.rstBenutzer = result.value;
    }, (result: any) => {

    });
  }

  editButtonClick(event: any, data: any) {
    this.dialogService.open(BenutzerBearbeitenComponent, { parameters: {Id: data.Id}, title: `Bearbeiten Benutzer` });
  }

  formBenutzerSubmit(event: any) {

  }

  button2Click(event: any) {
    this.notificationService.notify({ severity: "info", summary: `Test`, detail: `${this.rstBenutzer.Benutzername}` });
    console.log("test",this.rstBenutzer)
  }

  form0Submit(event: any) {
    this.dbSinDarEla.updateBenutzer(null, event.BenutzerID, event)
    .subscribe((result: any) => {

    }, (result: any) => {

    });
  }

  grid2Add(event: any) {
    this.dialogService.open(AddApplicationRoleComponent, { parameters: {}, title: 'Add Application Role' });
  }

  grid2Delete(event: any) {
    this.security.deleteRole(`${event.Id}`)
    .subscribe((result: any) => {
      this.notificationService.notify({ severity: "info", summary: `Success`, detail: `Role "${event.Name}" has been deleted.` });
    }, (result: any) => {
      this.notificationService.notify({ severity: "error", summary: `Cannot delete role`, detail: `${result.error.message}` });
    });
  }
}
