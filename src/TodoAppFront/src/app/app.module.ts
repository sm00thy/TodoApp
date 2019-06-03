import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatButtonModule, MatCheckboxModule, MatDividerModule, MatInputModule} from '@angular/material';
import { MatToolbarModule} from '@angular/material';
import { TodoListComponent } from './todo-list/todo-list.component';
import { RouterModule, Routes} from '@angular/router';
import { MatListModule } from '@angular/material/list';
import { HttpClientModule } from '@angular/common/http';
import { TodoService } from './shared/todo.service';
import { TodoItemManagerComponent } from './todo-item-manager/todo-item-manager.component';
import { AppRoutingModule } from './app-routing.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { TextFieldModule } from '@angular/cdk/text-field';
import {FormsModule} from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    TodoListComponent,
    TodoItemManagerComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatCheckboxModule,
    MatToolbarModule,
    MatCheckboxModule,
    MatListModule,
    MatDividerModule,
    HttpClientModule,
    AppRoutingModule,
    MatFormFieldModule,
    TextFieldModule,
    MatInputModule,
    MatButtonModule,
    FormsModule
  ],
  providers: [
    TodoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
