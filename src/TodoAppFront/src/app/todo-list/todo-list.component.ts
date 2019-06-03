import { Component, OnInit } from '@angular/core';
import {TodoItem} from '../model/todoItem';
import {TodoService} from '../shared/todo.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.scss']
})

export class TodoListComponent implements OnInit {

  isItemChecked = false;
  items: Array<TodoItem>;

  constructor(private itemsSvc: TodoService) {
  }

  ngOnInit() {
    this.itemsSvc.getItems().subscribe(
      (data) => this.items = data
    );
  }

}
