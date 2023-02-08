import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from "./pages/home/home.component";
import {BlogpostComponent} from "./pages/blogpost/blogpost.component";
import {ProfileComponent} from "./pages/profile/profile.component";

const routes: Routes = [
  {
    path: "home",
    component: HomeComponent
  },
  {
    path: "post/:id",
    component: BlogpostComponent
  },
  {
    path: "profile/:id",
    component: ProfileComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
