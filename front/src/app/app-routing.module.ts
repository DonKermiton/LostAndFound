import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LayoutLoggedComponent} from './share/components/layout-logged/layout-logged.component';

const routes: Routes = [
  {
    path: 'core',
    loadChildren: () => import('./core/core.module').then(m => m.CoreModule)
  },
  {
    path: '',
    loadChildren: () => import('./user/user.module').then(m => m.UserModule),
    component: LayoutLoggedComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
