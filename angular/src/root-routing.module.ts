import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';

const routes: Routes = [
    { path: '', redirectTo: '/app/about', pathMatch: 'full' },
    {
        path: 'account',
        loadChildren: () => import('account/account.module').then(m => m.AccountModule), // Lazy load account module
        data: { preload: true }
    },
    {
        path: 'app',
        loadChildren: () => import('app/app.module').then(m => m.AppModule), // Lazy load account module
        data: { preload: true }
    }
];

@NgModule({
    // imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
    imports: [RouterModule.forRoot(routes, { useHash: true })],
    exports: [RouterModule],
    providers: [ 
        {provide: LocationStrategy, useClass: HashLocationStrategy}
    ]
})
export class RootRoutingModule { }
