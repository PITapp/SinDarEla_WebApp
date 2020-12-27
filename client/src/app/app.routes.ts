import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { LoginLayoutComponent } from './login-layout/login-layout.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { ManagementComponent } from './management/management.component';
import { BenutzerNeuComponent } from './benutzer-neu/benutzer-neu.component';
import { BenutzerBearbeitenComponent } from './benutzer-bearbeiten/benutzer-bearbeiten.component';
import { BenutzerComponent } from './benutzer/benutzer.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DienstplanComponent } from './dienstplan/dienstplan.component';
import { MitarbeiterComponent } from './mitarbeiter/mitarbeiter.component';
import { KundenComponent } from './kunden/kunden.component';
import { KontakteComponent } from './kontakte/kontakte.component';
import { DokumenteComponent } from './dokumente/dokumente.component';
import { AuswertungenComponent } from './auswertungen/auswertungen.component';
import { AbrechnungComponent } from './abrechnung/abrechnung.component';
import { EinstellungenComponent } from './einstellungen/einstellungen.component';
import { MeinBenutzerprofilComponent } from './mein-benutzerprofil/mein-benutzerprofil.component';
import { ImpressumComponent } from './impressum/impressum.component';
import { DatenschutzComponent } from './datenschutz/datenschutz.component';
import { NachrichtenComponent } from './nachrichten/nachrichten.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { ApplicationUsersComponent } from './application-users/application-users.component';
import { LoginComponent } from './login/login.component';
import { AddApplicationRoleComponent } from './add-application-role/add-application-role.component';
import { ApplicationRolesComponent } from './application-roles/application-roles.component';
import { AddApplicationUserComponent } from './add-application-user/add-application-user.component';
import { RegisterApplicationUserComponent } from './register-application-user/register-application-user.component';
import { EditApplicationUserComponent } from './edit-application-user/edit-application-user.component';
import { ProfileComponent } from './profile/profile.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { BenutzerBearbeitenBenutzernameComponent } from './benutzer-bearbeiten-benutzername/benutzer-bearbeiten-benutzername.component';

import { SecurityService } from './security.service';
import { AuthGuard } from './auth.guard';
export const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: 'management',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: ManagementComponent
      },
      {
        path: 'benutzer-neu',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: BenutzerNeuComponent
      },
      {
        path: 'benutzer-bearbeiten/:Id',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: BenutzerBearbeitenComponent
      },
      {
        path: 'benutzer',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated', 'Administrator'],
        },
        component: BenutzerComponent
      },
      {
        path: 'dashboard',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: DashboardComponent
      },
      {
        path: 'dienstplan',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: DienstplanComponent
      },
      {
        path: 'mitarbeiter',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: MitarbeiterComponent
      },
      {
        path: 'kunden',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: KundenComponent
      },
      {
        path: 'kontakte',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: KontakteComponent
      },
      {
        path: 'dokumente',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: DokumenteComponent
      },
      {
        path: 'auswertungen',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AuswertungenComponent
      },
      {
        path: 'abrechnung',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AbrechnungComponent
      },
      {
        path: 'einstellungen',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EinstellungenComponent
      },
      {
        path: 'mein-benutzerprofil',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: MeinBenutzerprofilComponent
      },
      {
        path: 'impressum',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: ImpressumComponent
      },
      {
        path: 'datenschutz',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: DatenschutzComponent
      },
      {
        path: 'nachrichten',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: NachrichtenComponent
      },
      {
        path: 'feedback',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: FeedbackComponent
      },
      {
        path: 'application-users',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: ApplicationUsersComponent
      },
      {
        path: 'add-application-role',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddApplicationRoleComponent
      },
      {
        path: 'application-roles',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: ApplicationRolesComponent
      },
      {
        path: 'add-application-user',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddApplicationUserComponent
      },
      {
        path: 'register-application-user',
        data: {
          roles: ['Everybody'],
        },
        component: RegisterApplicationUserComponent
      },
      {
        path: 'edit-application-user/:Id',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EditApplicationUserComponent
      },
      {
        path: 'profile',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: ProfileComponent
      },
      {
        path: 'unauthorized',
        data: {
          roles: ['Everybody'],
        },
        component: UnauthorizedComponent
      },
      {
        path: 'benutzer-bearbeiten-benutzername',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: BenutzerBearbeitenBenutzernameComponent
      },
    ]
  },
  {
    path: '',
    component: LoginLayoutComponent,
    children: [
      {
        path: 'login',
        data: {
          roles: ['Everybody'],
        },
        component: LoginComponent
      },
    ]
  },
];

export const AppRoutes: ModuleWithProviders = RouterModule.forRoot(routes);
