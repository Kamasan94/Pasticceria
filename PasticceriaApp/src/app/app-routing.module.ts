import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { PasticceriaComponent } from './pasticceria/pasticceria.component';
import { DolciComponent } from './dolci/dolci.component';

const routes: Routes = [
  { path: 'vetrina', component: PasticceriaComponent },
  { path: 'dolci', component: DolciComponent }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

