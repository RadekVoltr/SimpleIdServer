import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '', redirectTo: 'home', pathMatch: 'full'
  },
  {
    path: 'home',
    loadChildren: async () => (await import('./home/home.module')).HomeModule
  },
  {
    path: 'applications',
    loadChildren: async () => (await import('./applications/applications.module')).ApplicationsModule
  },
  {
    path: 'scopes',
    loadChildren: async () => (await import('./scopes/scopes.module')).ScopesModule
  },
  {
    path: 'users',
    loadChildren: async () => (await import('./users/users.module')).UsersModule
  },
  {
    path: 'groups',
    loadChildren: async () => (await import('./groups/groups.module')).GroupsModule
  },
  {
    path: 'provisioning',
    loadChildren: async () => (await import('./provisioning/provisioning.module')).ProvisioningModule
  },
  {
    path: 'humantaskinstances',
    loadChildren: async () => (await import('./humantaskinstances/humantaskinstances.module')).HumanTaskInstancesModule
  },
  {
    path: 'authentications',
    loadChildren: async () => (await import('./authentications/authentications.module')).AuthenticationsModule
  },
  {
    path: 'relyingparties',
    loadChildren: async() => (await import('./relyingparties/relyingparties.module')).RelyingPartiesModule
  },
  { path: '**', redirectTo: '/status/404' }
];
