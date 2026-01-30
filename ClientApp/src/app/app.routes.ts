import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', loadComponent: () => import('./pages/company-list/company-list.component').then(m => m.CompanyListComponent) },
  { path: 'companies/create', loadComponent: () => import('./pages/company-form/company-form.component').then(m => m.CompanyFormComponent) },
  { path: '**', redirectTo: '' }
];
