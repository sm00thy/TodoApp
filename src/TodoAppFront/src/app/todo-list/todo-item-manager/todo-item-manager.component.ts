import {Component, Input, OnChanges, OnInit, Output, SimpleChanges, EventEmitter, ChangeDetectorRef} from '@angular/core';
import {TodoItem} from '../../model/todoItem';
import {NgForm} from '@angular/forms';
import {TodoService} from '../../shared/todo.service';

@Component({
  selector: 'app-todo-item-manager',
  templateUrl: './todo-item-manager.component.html',
  styleUrls: ['./todo-item-manager.component.scss']
})
export class TodoItemManagerComponent implements OnInit {

  @Output() itemRefresh = new EventEmitter<TodoItem>();

  constructor(private todoService: TodoService) {}

  ngOnInit() {
  }

  create(form: NgForm) {
    const formValue = {
      text: form.value.newTodo
    };
    this.todoService.postItem(formValue).subscribe(() => {
      }),
      error => console.log(error);
    form.reset();
    this.itemRefresh.emit(formValue);
  }

}
