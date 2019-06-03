import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from '@angular/router';
import {TodoListComponent} from './todo-list/todo-list.component';

const appRoutes: Routes = [
  { path: '', component: TodoListComponent }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes),
  ]
})
export class AppRoutingModule { }
