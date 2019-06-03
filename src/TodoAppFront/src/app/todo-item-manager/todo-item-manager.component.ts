import {Component, OnInit} from '@angular/core';
import {TodoItem} from '../model/todoItem';
import {NgForm} from '@angular/forms';
import {TodoService} from '../shared/todo.service';

@Component({
  selector: 'app-todo-item-manager',
  templateUrl: './todo-item-manager.component.html',
  styleUrls: ['./todo-item-manager.component.scss']
})
export class TodoItemManagerComponent implements OnInit {

  item: TodoItem;

  constructor(private todoService: TodoService) { }

  ngOnInit() {
  }

  create(form: NgForm) {
    this.todoService.postItem(form).subscribe(() => {
      this.todoService.getItems().subscribe(items => {
        this.item = items;
      });
    }),
      error => console.log(error);
  }

  remove(id) {
    this.todoService.deleteItem(id).subscribe(),
    error => console.log(error);
  }

}
