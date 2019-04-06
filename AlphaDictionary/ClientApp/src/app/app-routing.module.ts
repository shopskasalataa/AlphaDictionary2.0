import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TranslationComponent } from './translation/translation.component';

const routes: Routes = [
  { path: '', redirectTo: 'translate', pathMatch: 'full' },
  { path: 'translate', component: TranslationComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }